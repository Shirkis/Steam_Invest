using Microsoft.AspNetCore.Mvc;
using Steam_Invest.BLL.DTO;
using Steam_Invest.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steam_Invest.PRL.Controllers
{
    [Route("api")]
    public class DictionaryController : Controller
    {
        private readonly IDictionaryService _dictionaryService;

        public DictionaryController(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }

        #region Game

        [HttpGet("game")]
        public async Task<IActionResult> GetGames()
        {
            var res = await _dictionaryService.GetGames();
            return Ok(res);
        }

        [HttpGet("game/{gameId}")]
        public async Task<IActionResult> GetGameById([FromRoute] int gameId)
        {
            var res = await _dictionaryService.GetGameById(gameId);
            return Ok(res);
        }

        [HttpPost("game")]
        public async Task<IActionResult> CreateGame([FromBody] GameDTO model)
        {
            await _dictionaryService.CreateGame(model);
            return Ok();
        }

        [HttpPut("game/{gameId}")]
        public async Task<IActionResult> UpdateGame([FromRoute] int gameId, [FromBody] GameDTO model)
        {
            await _dictionaryService.UpdateGame(gameId, model);
            return Ok();
        }

        [HttpDelete("game/{gameId}")]
        public async Task<IActionResult> DeleteGame([FromRoute] int gameId)
        {
            await _dictionaryService.DeleteGame(gameId);
            return Ok();
        }

        #endregion

        #region Currency

        [HttpGet("currency")]
        public async Task<IActionResult> GetCurrency()
        {
            var res = await _dictionaryService.GetCurrency();
            return Ok(res);
        }

        [HttpGet("currency/{currencyId}")]
        public async Task<IActionResult> GetCurrencyById([FromRoute] int currencyId)
        {
            var res = await _dictionaryService.GetCurrencyById(currencyId);
            return Ok(res);
        }

        [HttpPost("currency")]
        public async Task<IActionResult> CreateCurrency([FromBody] CurrencyDTO model)
        {
            await _dictionaryService.CreateCurrency(model);
            return Ok();
        }

        [HttpPut("currency/{currencyId}")]
        public async Task<IActionResult> UpdateCurrency([FromRoute] int currencyId, [FromBody] CurrencyDTO model)
        {
            await _dictionaryService.UpdateCurrency(currencyId, model);
            return Ok();
        }

        [HttpDelete("currency/{currencyId}")]
        public async Task<IActionResult> DeleteCurrency([FromRoute] int currencyId)
        {
            await _dictionaryService.DeleteCurrency(currencyId);
            return Ok();
        }

        #endregion
    }
}
