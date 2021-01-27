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
    public class BankDepartamentService : IBankDepartamentService
    {

        IUnitOfWork _uow { get; set; }
        private IMapper _mapper;
        private readonly IBankService _bankService;

        public BankDepartamentService(IUnitOfWork uow, IMapper mapper, IBankService bankService)
        {
            _uow = uow;
            _mapper = mapper;
            _bankService = bankService;
        }

        public async Task<BankDepartamentViewModel> GetBankDepartament(int departamentId)
        {
            var bankId = await _uow.BankDepartaments.Query()
                .Where(s => s.BankDepartamentId == departamentId)
                .Select(s => s.BankId)
                .FirstOrDefaultAsync();
            var cont = await _bankService.GetBankInContainer(bankId);
            var departament = cont.BankDepartaments.Where(s => s.BankDepartament.BankDepartamentId == departamentId).FirstOrDefault();
            var resdepartament = new BankDepartamentViewModel();
            resdepartament.BankDepartament.BankDepartamentId = departament.BankDepartament.BankDepartamentId;
            resdepartament.BankDepartament.BankDepartamentName = departament.BankDepartament.BankDepartamentName;
            resdepartament.BankDepartament.BankId = departament.BankDepartament.BankId;
            foreach (var employee in departament.BankEmployees)
            {
                if (employee != null)
                {
                    var employeeclass = new BankEmployeeViewModel();
                    employeeclass.BankEmployee.BankEmployeeId = employee.BankEmployee.BankEmployeeId;
                    employeeclass.BankEmployee.BankEmployeeName = employee.BankEmployee.BankEmployeeName;
                    employeeclass.BankEmployee.BankEmployeePosition = employee.BankEmployee.BankEmployeePosition;
                    employeeclass.BankEmployee.BankDepartamentId = employee.BankEmployee.BankDepartamentId;
                    resdepartament.BankEmployees.Enqueue(employeeclass);
                }
            }
            return resdepartament;
        }
        public async Task CreateDepartament(int bankId, BankDepartamentDTO model)
        {
            try
            {
                var newbankdep = _mapper.Map<BankDepartament>(model);
                newbankdep.BankId = bankId;
                _uow.BankDepartaments.Add(newbankdep);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateDepartament(int departamentId, BankDepartamentDTO model)
        {
            try
            {
                var bankdepartament = _mapper.Map<BankDepartament>(model);
                bankdepartament.BankDepartamentId = departamentId;
                _uow.BankDepartaments.Update(bankdepartament);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteDepartament(int departamentId)
        {
            try
            {
                var olddepartament = await _uow.BankDepartaments.Query()
                    .Where(s => s.BankDepartamentId == departamentId)
                    .Include(s => s.BankEmployees)
                    .FirstOrDefaultAsync();
                if (olddepartament == null)
                    throw new Exception($"Не удалось найти сущность");
                if (olddepartament.BankEmployees.Count != 0)
                {
                    throw new Exception($"Остались привязанные отделы");
                }

                _uow.BankDepartaments.DeleteById(departamentId);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
