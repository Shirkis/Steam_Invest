using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Steam_Invest.BLL.DTO;
using Steam_Invest.BLL.Interfaces;
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
        public async Task<ItemDTO> GetItemByName(string itemName, string game)
        {
            var client = new HttpClient();
            var urlcode = Uri.EscapeUriString(itemName);
            urlcode = urlcode.Replace("(", "%28").Replace(")", "%29");
            var gameId = 0;
            if (game.Contains("cs"))
            {
                gameId = 730;
            }
            var reqItem = await client.GetAsync($"https://steamcommunity.com/market/listings/{gameId}/{urlcode}");
            var itemstring = await reqItem.Content.ReadAsStringAsync();
            var findId = "Market_LoadOrderSpread";
            var fitmindex = itemstring.IndexOf(findId);
            var itemfirstcut = itemstring.Substring(fitmindex + 24);
            var sitemindex = itemfirstcut.IndexOf(")");
            var itemsecondcur = itemfirstcut.Substring(0, sitemindex - 1);
            var reqpriceurl = $"https://steamcommunity.com/market/itemordershistogram?country=RU&language=russian&currency=5&item_nameid={itemsecondcur}&two_factor=0";
            var reqprice = await client.GetAsync(reqpriceurl);
            var reqString = await reqprice.Content.ReadAsStringAsync();
            var findprice = "sell_order_graph";
            var firstindex = reqString.IndexOf(findprice);
            var firstcut = reqString.Substring(firstindex + 20);
            var secondindex = firstcut.IndexOf(",");
            var price = firstcut.Substring(0, secondindex);
            ItemDTO res = new ItemDTO
            {
                ItemName = itemName,
                Price = price
            };
            return res;
        }

        #endregion

        #region Portfolio

        public async Task<List<PortfolioDTO>> GetPortfolios()
        {
            var portfolios = await _uow.Portfolios.Query()
                .ToListAsync();

            var res = _mapper.Map<List<PortfolioDTO>>(portfolios);
            return res;
        }

        #endregion
    }
}
