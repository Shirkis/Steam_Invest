using Steam_Invest.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Invest.BLL.Interfaces
{
    public interface IDictionaryService
    {
        #region Game

        Task<List<GameDTO>> GetGames();
        Task<GameDTO> GetGameById(int gameId);
        Task CreateGame(GameDTO model);
        Task UpdateGame(int gameId, GameDTO model);
        Task DeleteGame(int gameId);

        #endregion

        #region Currency

        Task<List<CurrencyDTO>> GetCurrency();
        Task<CurrencyDTO> GetCurrencyById(int currencyId);
        Task CreateCurrency(CurrencyDTO model);
        Task UpdateCurrency(int currencyId, CurrencyDTO model);
        Task DeleteCurrency(int currencyId);

        #endregion
    }
}
