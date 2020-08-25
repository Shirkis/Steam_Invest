using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Steam_Invest.BLL.DTO;
using Steam_Invest.BLL.Interfaces;
using Steam_Invest.DAL.Entities;
using Steam_Invest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Invest.BLL.Services
{
    public class DictionaryService : IDictionaryService
    {
        IUnitOfWork _uow { get; set; }
        private IMapper _mapper;

        public DictionaryService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        #region Game

        public async Task<List<GameDTO>> GetGames()
        {
            try
            {
                var games = await _uow.Games.Query()
                    .ToListAsync();

                var res = _mapper.Map<List<GameDTO>>(games);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<GameDTO> GetGameById(int gameId)
        {
            try
            {
                var game = await _uow.Games.Query()
                    .Where(s => s.GameId == gameId)
                    .FirstOrDefaultAsync();

                var res = _mapper.Map<GameDTO>(game);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CreateGame(GameDTO model)
        {
            try
            {
                var newgame = _mapper.Map<Game>(model);
                _uow.Games.Add(newgame);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateGame(int gameId, GameDTO model)
        {
            try
            {
                var game = _mapper.Map<Game>(model);
                game.GameId = gameId;
                _uow.Games.Update(game);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteGame(int gameId)
        {
            try
            {
                var oldgame = await _uow.Games.Query()
                    .Where(s => s.GameId == gameId)
                    .FirstOrDefaultAsync();
                if (oldgame == null)
                    throw new Exception($"Не удалось найти сущность");

                _uow.Games.DeleteById(gameId);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion


        #region Currency

        public async Task<List<CurrencyDTO>> GetCurrency()
        {
            try
            {
                var currencies = await _uow.Currencies.Query()
                    .ToListAsync();

                var res = _mapper.Map<List<CurrencyDTO>>(currencies);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CurrencyDTO> GetCurrencyById(int currencyId)
        {
            try
            {
                var currency = await _uow.Currencies.Query()
                    .Where(s => s.CurrencyId == currencyId)
                    .FirstOrDefaultAsync();

                var res = _mapper.Map<CurrencyDTO>(currency);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CreateCurrency(CurrencyDTO model)
        {
            try
            {
                var newcurrency = _mapper.Map<Currency>(model);
                _uow.Currencies.Add(newcurrency);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateCurrency(int currencyId, CurrencyDTO model)
        {
            try
            {
                var currency = _mapper.Map<Currency>(model);
                currency.CurrencyId = currencyId;
                _uow.Currencies.Update(currency);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteCurrency(int currencyId)
        {
            try
            {
                var oldcurrency = await _uow.Currencies.Query()
                    .Where(s => s.CurrencyId == currencyId)
                    .FirstOrDefaultAsync();
                if (oldcurrency == null)
                    throw new Exception($"Не удалось найти сущность");

                _uow.Currencies.DeleteById(currencyId);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}
