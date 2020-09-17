using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Steam_Invest.BLL.DTO;
using Steam_Invest.BLL.Interfaces;
using Steam_Invest.DAL.Entities;
using Steam_Invest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Invest.BLL.Services
{
    public class ItemService : IItemService
    {

        IUnitOfWork _uow { get; set; }
        private IMapper _mapper;

        public ItemService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        #region Item
        //public async Task<ItemDTO> GetItemByName(string itemName, string game)
        //{
        //    var client = new HttpClient();
        //    var urlcode = Uri.EscapeUriString(itemName);
        //    urlcode = urlcode.Replace("(", "%28").Replace(")", "%29");
        //    var gameId = 0;
        //    if (game.Contains("cs"))
        //    {
        //        gameId = 730;
        //    }
        //    var reqItem = await client.GetAsync($"https://steamcommunity.com/market/listings/{gameId}/{urlcode}");
        //    var itemstring = await reqItem.Content.ReadAsStringAsync();
        //    var findId = "Market_LoadOrderSpread";
        //    var fitmindex = itemstring.IndexOf(findId);
        //    var itemfirstcut = itemstring.Substring(fitmindex + 24);
        //    var sitemindex = itemfirstcut.IndexOf(")");
        //    var itemsecondcur = itemfirstcut.Substring(0, sitemindex - 1);
        //    var reqpriceurl = $"https://steamcommunity.com/market/itemordershistogram?country=RU&language=russian&currency=5&item_nameid={itemsecondcur}&two_factor=0";
        //    var reqprice = await client.GetAsync(reqpriceurl);
        //    var reqString = await reqprice.Content.ReadAsStringAsync();
        //    var findprice = "sell_order_graph";
        //    var firstindex = reqString.IndexOf(findprice);
        //    var firstcut = reqString.Substring(firstindex + 20);
        //    var secondindex = firstcut.IndexOf(",");
        //    var price = firstcut.Substring(0, secondindex);
        //    ItemDTO res = new ItemDTO
        //    {
        //        ItemName = itemName,
        //        Price = price
        //    };
        //    return res;
        //}

        public async Task<List<ItemInfoDTO>> GetItemsByPortfolio(int portfolioId)
        {
            try
            {
                var items = await _uow.Items.Query()
                    .Where(s => s.PortfolioId == portfolioId)
                    .ToListAsync();

                var res = _mapper.Map<List<ItemInfoDTO>>(items);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ItemInfoDTO> GetItemById(int itemId)
        {
            try
            {
                var item = await _uow.Items.Query()
                    .Where(s => s.ItemId == itemId)
                    .FirstOrDefaultAsync();

                var res = _mapper.Map<ItemInfoDTO>(item);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CreateItem(ItemChangeDTO model)
        {
            try
            {
                var newitem = _mapper.Map<Item>(model);
                _uow.Items.Add(newitem);
                await _uow.SaveChangesAsync();

                await CreatePurchase(model.Purchase);
                //var newpurchase = _mapper.Map<Purchase>(model.Purchase);
                //newpurchase.ItemId = newitem.ItemId;
                //_uow.Purchases.Add(newpurchase);
                //await _uow.SaveChangesAsync();
                //var portfolio = await _uow.Portfolios.Query()
                //    .Where(s => s.PortfolioId == model.PortfolioId)
                //    .FirstOrDefaultAsync();
                //portfolio.Balance -= model.Purchase.BuyPrice * model.Purchase.BuyCount;
                //_uow.Portfolios.Update(portfolio);
                //await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //не используется
        public async Task UpdateItem(int itemId, ItemChangeDTO model)
        {
            try
            {
                var item = _mapper.Map<Item>(model);
                item.ItemId= itemId;
                _uow.Items.Update(item);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteItem(int itemId)
        {
            try
            {
                var olditem = await _uow.Items.Query()
                    .Where(s => s.ItemId == itemId)
                    .Include(s => s.Purchases)
                    .FirstOrDefaultAsync();
                if (olditem == null)
                    throw new Exception($"Не удалось найти сущность");

                foreach (var purch in olditem.Purchases)
                {
                    _uow.Purchases.DeleteById(purch.PurchaseId);
                }
                await _uow.SaveChangesAsync();
                _uow.Items.DeleteById(itemId);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Purchase

        public async Task<List<PurchaseInfoDTO>> GetPurchaseByItem(int itemId)
        {
            try
            {
                var purchases = await _uow.Purchases.Query()
                    .Where(s => s.ItemId == itemId)
                    .ToListAsync();
                var res = _mapper.Map<List<PurchaseInfoDTO>>(purchases);
                foreach (var r in res)
                {
                    r.SumPrice = r.Price * r.Count;
                }
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PurchaseInfoDTO> GetPurchaseById(int purchaseId)
        {
            try
            {
                var purchase = await _uow.Purchases.Query()
                    .Where(s => s.ItemId == purchaseId)
                    .FirstOrDefaultAsync();

                var res = _mapper.Map<PurchaseInfoDTO>(purchase);
                res.SumPrice = res.Price * res.Count;
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CreatePurchase(PurchaseDTO model)
        {
            try
            {
                var item = await _uow.Items.Query()
                    .Where(s => s.ItemId == model.ItemId)
                    .Include(s => s.Purchases)
                    .FirstOrDefaultAsync();
                decimal? sumprice = 0;
                foreach (var purch in item.Purchases)
                {
                    sumprice += purch.Price * purch.Count;
                }
                if (model.IsSale == false)
                {
                    item.AllBuyCount = item.AllBuyCount + model.Count;
                    item.AvgBuyPrice = (sumprice + (model.Price * model.Count)) / item.AllBuyCount;
                    item.SumBuyPrice = sumprice + (model.Price * model.Count);
                }
                else
                {
                    item.AllBuyCount = item.AllBuyCount - model.Count;
                    item.AvgBuyPrice = (sumprice - (model.Price * model.Count)) / item.AllBuyCount;
                    item.SumBuyPrice = sumprice - (model.Price * model.Count);
                }
                _uow.Items.Update(item);
                var newpurchase = _mapper.Map<Purchase>(model);
                _uow.Purchases.Add(newpurchase);
                await _uow.SaveChangesAsync();

                var portfolio = await _uow.Items.Query()
                    .Where(s => s.ItemId == model.ItemId)
                    .Include(s => s.Portfolio)
                    .Select(s => s.Portfolio)
                    .FirstOrDefaultAsync();
                if (model.IsSale == false)
                {
                    portfolio.Balance -= model.Price * model.Count;
                }
                else
                {
                    portfolio.Balance += model.Price * model.Count;
                }
                _uow.Portfolios.Update(portfolio);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdatePurchase(int purchaseId, PurchaseDTO model)
        {
            try
            {
                var oldpurchase = await _uow.Purchases.Query()
                    .Where(s => s.PurchaseId == purchaseId)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
                var purchase = _mapper.Map<Purchase>(model);
                purchase.PurchaseId = purchaseId;
                _uow.Purchases.Update(purchase);
                await _uow.SaveChangesAsync();
                var itemId = await _uow.Purchases.Query()
                    .Where(s => s.PurchaseId == purchaseId)
                    .Include(s => s.Item)
                    .Select(s => s.ItemId)
                    .FirstOrDefaultAsync();
                var item = await _uow.Items.Query()
                    .Where(s => s.ItemId == itemId)
                    .Include(s => s.Purchases)
                    .FirstOrDefaultAsync();
                decimal? sumprice = 0;
                int? sumcount = 0;
                foreach (var purch in item.Purchases)
                {
                    if (purch.IsSale == false)
                    {
                        sumprice += purch.Price * purch.Count;
                        sumcount += purch.Count;
                    }
                    else
                    {
                        sumprice -= purch.Price * purch.Count;
                        sumcount -= purch.Count;
                    }
                }
                item.AllBuyCount = sumcount;
                item.AvgBuyPrice = sumprice / sumcount;
                item.SumBuyPrice = sumprice;
                if (item.FirstBuyDate > model.Date)
                {
                    item.FirstBuyDate = model.Date;
                }
                _uow.Items.Update(item);
                await _uow.SaveChangesAsync();

                var portfolio = await _uow.Portfolios.Query()
                    .Where(s => s.PortfolioId == item.PortfolioId)
                    .FirstOrDefaultAsync();
                if (oldpurchase.IsSale == false)
                {
                    portfolio.Balance += oldpurchase.Price * oldpurchase.Count;
                    portfolio.Balance -= model.Price * model.Count;
                }
                else
                {
                    portfolio.Balance -= oldpurchase.Price * oldpurchase.Count;
                    portfolio.Balance += model.Price * model.Count;
                }
                _uow.Portfolios.Update(portfolio);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeletePurchase(int purchaseId)
        {
            try
            {
                var oldpurchase = await _uow.Purchases.Query()
                    .Where(s => s.PurchaseId == purchaseId)
                    .FirstOrDefaultAsync();
                if (oldpurchase== null)
                    throw new Exception($"Не удалось найти сущность");

                var itemId = oldpurchase.ItemId;
                _uow.Purchases.DeleteById(purchaseId);
                await _uow.SaveChangesAsync();
                var item = await _uow.Items.Query()
                    .Where(s => s.ItemId == itemId)
                    .Include(s => s.Purchases)
                    .FirstOrDefaultAsync();
                decimal? sumprice = 0;
                int? sumcount = 0;
                DateTime? fday = new DateTime(9999, 1, 1);
                foreach (var purch in item.Purchases)
                {
                    if (purch.IsSale == false)
                    {
                        sumprice += purch.Price * purch.Count;
                        sumcount += purch.Count;
                    }
                    else
                    {
                        sumprice -= purch.Price * purch.Count;
                        sumcount -= purch.Count;
                    }
                    if (fday > purch.Date)
                    {
                        fday = purch.Date;
                    }
                }
                item.AllBuyCount = sumcount;
                item.AvgBuyPrice = sumprice / sumcount;
                item.SumBuyPrice = sumprice;
                item.FirstBuyDate = fday;
                _uow.Items.Update(item);
                await _uow.SaveChangesAsync();

                var portfolio = await _uow.Portfolios.Query()
                    .Where(s => s.PortfolioId == item.PortfolioId)
                    .FirstOrDefaultAsync();
                if (oldpurchase.IsSale == false)
                {
                    portfolio.Balance += oldpurchase.Price * oldpurchase.Count;
                }
                else
                {
                    portfolio.Balance -= oldpurchase.Price * oldpurchase.Count;
                }
                _uow.Portfolios.Update(portfolio);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Portfolio

        public async Task<List<PortfolioDTO>> GetPortfolios()
        {
            try
            {
                var portfolios = await _uow.Portfolios.Query()
                    .ToListAsync();

                var res = _mapper.Map<List<PortfolioDTO>>(portfolios);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PortfolioDTO> GetPortfolioById(int portfolioId)
        {
            try
            {
                var portfolio = await _uow.Portfolios.Query()
                    .Where(s => s.PortfolioId == portfolioId)
                    .FirstOrDefaultAsync();

                var res = _mapper.Map<PortfolioDTO>(portfolio);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CreatePortfolio(PortfolioDTO model)
        {
            try
            {
                var newportfolio = _mapper.Map<Portfolio>(model);
                _uow.Portfolios.Add(newportfolio);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdatePortfolio(int portfolioId, PortfolioDTO model)
        {
            try
            {
                var portfolio = _mapper.Map<Portfolio>(model);
                portfolio.PortfolioId = portfolioId;
                _uow.Portfolios.Update(portfolio);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeletePortfolio(int portfolioId)
        {
            try
            {
                var oldportfolio = await _uow.Portfolios.Query()
                    .Where(s => s.PortfolioId == portfolioId)
                    .FirstOrDefaultAsync();
                if (oldportfolio == null)
                    throw new Exception($"Не удалось найти сущность");

                _uow.Portfolios.DeleteById(portfolioId);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task AddBalancePortfolio(int portfolioId, decimal balance)
        {
            var portfolio = await _uow.Portfolios.Query()
                .Where(s => s.PortfolioId == portfolioId)
                .FirstOrDefaultAsync();
            portfolio.Balance += balance;
            _uow.Portfolios.Update(portfolio);
            await _uow.SaveChangesAsync();
        }

        #endregion
    }
}
