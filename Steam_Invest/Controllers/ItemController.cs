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

        //[HttpGet("item/{itemName}")]
        //public async Task<IActionResult> GetItemByName([FromRoute] string itemName, string game)
        //{
        //    var res = await _itemService.GetItemByName(itemName, game);
        //    return Ok(res);
        //}

        [HttpGet("portfolio/{portfolioId}/items")]
        public async Task<IActionResult> GetItemsByPortfolio([FromRoute] int portfolioId)
        {
            var res = await _itemService.GetItemsByPortfolio(portfolioId);
            return Ok(res);
        }

        [HttpGet("item/{itemId}")]
        public async Task<IActionResult> GetItemById([FromRoute] int itemId)
        {
            var res = await _itemService.GetItemById(itemId);
            return Ok(res);
        }

        [HttpPost("item")]
        public async Task<IActionResult> CreateItem([FromBody] ItemDTO model)
        {
            await _itemService.CreateItem(model);
            return Ok();
        }

        [HttpPut("item/{itemId}")]
        public async Task<IActionResult> UpdateItem([FromRoute] int itemId, [FromBody] ItemDTO model)
        {
            await _itemService.UpdateItem(itemId, model);
            return Ok();
        }

        [HttpDelete("item/{itemId}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int itemId)
        {
            await _itemService.DeleteItem(itemId);
            return Ok();
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
