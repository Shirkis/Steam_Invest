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
    public class BankEmployeeService : IBankEmployeeService
    {

        IUnitOfWork _uow { get; set; }
        private IMapper _mapper;
        private readonly IBankService _bankService;

        public BankEmployeeService(IUnitOfWork uow, IMapper mapper, IBankService bankService)
        {
            _uow = uow;
            _mapper = mapper;
            _bankService = bankService;
        }

        public async Task<BankEmployeeViewModel> GetBankEmployee(int employeeId)
        {
            var bankdepartament = await _uow.BankEmployees.Query()
                .Where(s => s.BankEmployeeId == employeeId)
                .Include(s => s.BankDepartament)
                .Select(s => s.BankDepartament)
                .FirstOrDefaultAsync();
            var cont = await _bankService.GetBankInContainer(bankdepartament.BankId);
            var departament = cont.BankDepartaments.Where(s => s.BankDepartament.BankDepartamentId == bankdepartament.BankDepartamentId).FirstOrDefault();
            var employee = departament.BankEmployees.Where(s => s.BankEmployee.BankEmployeeId == employeeId).FirstOrDefault();
            if (employee != null)
            {
                var employeeclass = new BankEmployeeViewModel();
                employeeclass.BankEmployee.BankEmployeeId = employee.BankEmployee.BankEmployeeId;
                employeeclass.BankEmployee.BankEmployeeName = employee.BankEmployee.BankEmployeeName;
                employeeclass.BankEmployee.BankEmployeePosition = employee.BankEmployee.BankEmployeePosition;
                employeeclass.BankEmployee.BankDepartamentId = employee.BankEmployee.BankDepartamentId;
            return employeeclass;
            }
            return null;
        }

        public async Task CreateEmployee(int departamentId, BankEmployeeDTO model)
        {
            try
            {
                var bankId = await _uow.BankDepartaments.Query()
                .Where(s => s.BankDepartamentId == departamentId)
                .Select(s => s.BankId)
                .FirstOrDefaultAsync();
                var cont = await _bankService.GetBankInContainer(bankId);
                var departament = cont.BankDepartaments.Where(s => s.BankDepartament.BankDepartamentId == departamentId).FirstOrDefault();
                if (departament.BankEmployees.IsFull != true)
                {
                    var newbankemployee = _mapper.Map<BankEmployee>(model);
                    newbankemployee.BankDepartamentId = departamentId;
                    _uow.BankEmployees.Add(newbankemployee);
                    await _uow.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Очередь сотрудников полна");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateEmployee(int employeeId, BankEmployeeDTO model)
        {
            try
            {
                var bankemployee = _mapper.Map<BankEmployee>(model);
                bankemployee.BankEmployeeId = employeeId;
                _uow.BankEmployees.Update(bankemployee);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteEmployee(int employeeId)
        {
            try
            {
                var oldemployee = await _uow.BankEmployees.Query()
                    .Where(s => s.BankEmployeeId == employeeId)
                    .FirstOrDefaultAsync();
                if (oldemployee == null)
                    throw new Exception($"Не удалось найти сущность");

                _uow.BankEmployees.DeleteById(employeeId);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
