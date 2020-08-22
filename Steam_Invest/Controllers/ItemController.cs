using Microsoft.AspNetCore.Mvc;
using Steam_Invest.BLL.Interfaces;
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

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
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

        //[HttpGet("portfolio/{portfolioId}")]
        //public async Task<IActionResult> GetPortfolioById()
        //{
        //    var res = await
        //}

        #endregion
    }
}
