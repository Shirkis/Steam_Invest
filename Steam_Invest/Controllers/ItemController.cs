using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Steam_Invest.BLL.DTO;
using Steam_Invest.BLL.Interfaces;
using Steam_Invest.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steam_Invest.PRL.Controllers
{
    [Route("api")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly UserManager<AspNetUser> _userManager;

        public ItemController(IItemService itemService, UserManager<AspNetUser> userManager)
        {
            _itemService = itemService;
            _userManager = userManager;
        }

        #region Item

        [HttpGet("item/{itemName}")]
        public async Task<IActionResult> GetItemByName([FromRoute] string itemName, string game)
        {
            var res = await _itemService.GetItemByName(itemName, game);
            return Ok(res);
        }

        #endregion

        #region Portfolio

        [HttpGet("portfolio")]
        public async Task<IActionResult> GetPortfolios()
        {
            var res = await _itemService.GetPortfolios();
            return Ok(res);
        }

        [HttpGet("portfolio/{portfolioId}")]
        public async Task<IActionResult> GetPortfolioById([FromRoute] int portfolioId)
        {
            var res = await _itemService.GetPortfolioById(portfolioId);
            return Ok(res);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("portfolio")]
        public async Task<IActionResult> CreatePortfolio([FromBody] PortfolioDTO model)
        {
            await _itemService.CreatePortfolio(model);
            return Ok();
        }

        [HttpPut("portfolio/{portfolioId}")]
        public async Task<IActionResult> UpdatePortfolio([FromRoute] int portfolioId, [FromBody] PortfolioDTO model)
        {
            await _itemService.UpdatePortfolio(portfolioId, model);
            return Ok();
        }

        [HttpDelete("portfolio/{portfolioId}")]
        public async Task<IActionResult> DeletePortfolio([FromRoute] int portfolioId)
        {
            await _itemService.DeletePortfolio(portfolioId);
            return Ok();
        }
        #endregion
    }
}
