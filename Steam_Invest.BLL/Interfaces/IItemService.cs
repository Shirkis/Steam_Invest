using Steam_Invest.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Invest.BLL.Interfaces
{
    public interface IItemService
    {
        #region Item

        //Task<ItemDTO> GetItemByName(string itemName, string game);

        Task<List<ItemInfoDTO>> GetItemsByPortfolio(int portfolioId);
        Task<ItemInfoDTO> GetItemById(int itemId);
        Task CreateItem(ItemChangeDTO model);
        Task UpdateItem(int itemId, ItemChangeDTO model);
        Task DeleteItem(int itemId);

        #endregion

        #region Portfolio

        Task<List<PortfolioDTO>> GetPortfolios();

        Task<PortfolioDTO> GetPortfolioById(int portfolioId);
        Task CreatePortfolio(PortfolioDTO model);
        Task UpdatePortfolio(int portfolioId, PortfolioDTO model);
        Task DeletePortfolio(int portfolioId);

        #endregion

        #region Purchase

        Task<List<PurchaseInfoDTO>> GetPurchaseByItem(int itemId);
        Task<PurchaseInfoDTO> GetPurchaseById(int purchaseId);
        Task CreatePurchase(PurchaseDTO model);
        Task UpdatePurchase(int purchaseId, PurchaseDTO model);
        Task DeletePurchase(int purchaseId);

        #endregion
    }
}
