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
    public class BankController : Controller
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        #region Bank

        /// <summary>
        /// Список банков
        /// </summary>
        /// <returns></returns>
        [HttpGet("bank")]
        public async Task<IActionResult> GetBanks()
        {
            var res = await _bankService.GetBanks();
            return Ok(res);
        }

        /// <summary>
        /// Информация о банке
        /// </summary>
        /// <returns></returns>
        [HttpGet("bank/{bankId}")]
        public async Task<IActionResult> GetBank([FromRoute] int bankId)
        {
            var res = await _bankService.GetBank(bankId);
            return Ok(res);
        }

        /// <summary>
        /// Создать банк
        /// </summary>
        /// <returns></returns>
        [HttpPost("bank")]
        public async Task<IActionResult> CreateBank([FromBody] BankDTO model)
        {
            await _bankService.CreateBank(model);
            return Ok();
        }

        /// <summary>
        /// Редактировать банк
        /// </summary>
        /// <returns></returns>
        [HttpPut("bank/{bankId}")]
        public async Task<IActionResult> UpdateBank([FromRoute] int bankId, [FromBody] BankDTO model)
        {
            await _bankService.UpdateBank(bankId, model);
            return Ok();
        }

        /// <summary>
        /// Удалить банк
        /// </summary>
        /// <returns></returns>
        [HttpDelete("bank/{bankId}")]
        public async Task<IActionResult> DeleteBank([FromRoute] int bankId)
        {
            await _bankService.DeleteBank(bankId);
            return Ok();
        }

        #endregion
    }
}
