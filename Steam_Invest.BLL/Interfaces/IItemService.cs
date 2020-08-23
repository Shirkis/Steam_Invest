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

        Task<ItemDTO> GetItemByName(string itemName, string game);
        
        #endregion

        #region Portfolio

        Task<List<PortfolioDTO>> GetPortfolios();

        Task<PortfolioDTO> GetPortfolioById(int portfolioId);
        Task CreatePortfolio(PortfolioDTO model);
        Task UpdatePortfolio(int portfolioId, PortfolioDTO model);
        Task DeletePortfolio(int portfolioId);

        #endregion
    }
}
