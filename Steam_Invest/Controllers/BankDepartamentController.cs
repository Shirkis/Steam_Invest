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
    public class BankDepartamentController : Controller
    {
        private readonly IBankDepartamentService _bankDepartamentService;

        public BankDepartamentController(IBankDepartamentService bankDepartamentService)
        {
            _bankDepartamentService = bankDepartamentService;
        }

        #region BankDepartament

        /// <summary>
        /// Информация о отделе
        /// </summary>
        /// <returns></returns>
        [HttpGet("departament/{departamentId}")]
        public async Task<IActionResult> GetBankDepartament([FromRoute] int departamentId)
        {
            var res = await _bankDepartamentService.GetBankDepartament(departamentId);
            return Ok(res);
        }

        /// <summary>
        /// Создание отдела
        /// </summary>
        /// <returns></returns>
        [HttpPost("departament/{bankId}")]
        public async Task<IActionResult> CreateDepartament([FromRoute] int bankId, [FromBody] BankDepartamentDTO model)
        {
            await _bankDepartamentService.CreateDepartament(bankId, model);
            return Ok();
        }

        /// <summary>
        /// Редактирование отдела
        /// </summary>
        /// <returns></returns>
        [HttpPut("departament/{departamentId}")]
        public async Task<IActionResult> UpdateDepartament([FromRoute] int departamentId, [FromBody] BankDepartamentDTO model)
        {
            await _bankDepartamentService.UpdateDepartament(departamentId, model);
            return Ok();
        }

        /// <summary>
        /// Удаление отдела
        /// </summary>
        /// <returns></returns>
        [HttpDelete("departament/{departamentId}")]
        public async Task<IActionResult> DeleteDepartament([FromRoute] int departamentId)
        {
            await _bankDepartamentService.DeleteDepartament(departamentId);
            return Ok();
        }

        #endregion
    }
}
