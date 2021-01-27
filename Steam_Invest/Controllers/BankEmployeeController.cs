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
    public class BankEmployeeController : Controller
    {
        private readonly IBankEmployeeService _bankEmployeeService;

        public BankEmployeeController(IBankEmployeeService bankEmployeeService)
        {
            _bankEmployeeService = bankEmployeeService;
        }


        #region BankEmployee

        /// <summary>
        /// Информация о сотруднике
        /// </summary>
        /// <returns></returns>
        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetBankEmployee([FromRoute] int employeeId)
        {
            var res = await _bankEmployeeService.GetBankEmployee(employeeId);
            return Ok(res);
        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <returns></returns>
        [HttpPost("employee/{departamentId}")]
        public async Task<IActionResult> CreateEmployee([FromRoute] int departamentId, [FromBody] BankEmployeeDTO model)
        {
            await _bankEmployeeService.CreateEmployee(departamentId, model);
            return Ok();
        }

        /// <summary>
        /// Редактирование сотрудника
        /// </summary>
        /// <returns></returns>
        [HttpPut("employee/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int employeeId, [FromBody] BankEmployeeDTO model)
        {
            await _bankEmployeeService.UpdateEmployee(employeeId, model);
            return Ok();
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <returns></returns>
        [HttpDelete("employee/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int employeeId)
        {
            await _bankEmployeeService.DeleteEmployee(employeeId);
            return Ok();
        }

        #endregion
    }
}
