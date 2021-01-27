using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Steam_Invest.BLL.BankClasses;
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
    public class BankService : IBankService
    {

        IUnitOfWork _uow { get; set; }
        private IMapper _mapper;

        public BankService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        #region Bank

        /// <summary>
        /// Список банков
        /// </summary>
        /// <returns></returns>
        public async Task<List<BankDTO>> GetBanks()
        {
            try
            {
                var banks = await _uow.Banks.Query()
                    .ToListAsync();

                var res = _mapper.Map<List<BankDTO>>(banks);
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Получение информации о банке из бд и запись в контейнер
        /// </summary>
        /// <returns></returns>
        public async Task<BankClass> GetBankInContainer(int bankId)
        {
            try
            {
                var bank = await _uow.Banks.Query()
                    .Where(s => s.BankId == bankId)
                    .Include(s => s.BankDepartaments)
                    .ThenInclude(s => s.BankEmployees)
                    .FirstOrDefaultAsync();

                var res = new BankClass();
                res.Bank.BankId = bank.BankId;
                res.Bank.BankName = bank.BankName;
                foreach (var departament in bank.BankDepartaments)
                {
                    var departamentclass = new BankDepartamentClass();
                    departamentclass.BankDepartament.BankDepartamentId = departament.BankDepartamentId;
                    departamentclass.BankDepartament.BankDepartamentName = departament.BankDepartamentName;
                    departamentclass.BankDepartament.BankId = departament.BankId;
                    foreach (var employee in departament.BankEmployees)
                    {
                        var employeeclass = new BankEmployeeClass();
                        employeeclass.BankEmployee.BankEmployeeId = employee.BankEmployeeId;
                        employeeclass.BankEmployee.BankEmployeeName = employee.BankEmployeeName;
                        employeeclass.BankEmployee.BankEmployeePosition = employee.BankEmployeePosition;
                        employeeclass.BankEmployee.BankDepartamentId = employee.BankDepartamentId;
                        departamentclass.BankEmployees.Enqueue(employeeclass);
                    }
                    res.BankDepartaments.Add(departamentclass);
                }
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// Вывод информации о банке
        /// </summary>
        /// <returns></returns>
        public async Task<BankViewModel> GetBank(int bankId)
        {
            var cont = await GetBankInContainer(bankId);
            var res = new BankViewModel();
            res.Bank.BankId = cont.Bank.BankId;
            res.Bank.BankName = cont.Bank.BankName;
            foreach (var departament in cont.BankDepartaments)
            {
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
                res.BankDepartaments.Add(resdepartament);
            }
            return res;
        }

        public async Task CreateBank(BankDTO model)
        {
            try
            {
                var newbank = _mapper.Map<Bank>(model);
                _uow.Banks.Add(newbank);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateBank(int bankId, BankDTO model)
        {
            try
            {
                var bank = _mapper.Map<Bank>(model);
                bank.BankId = bankId;
                _uow.Banks.Update(bank);
                await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteBank(int bankId)
        {
            try
            {
                var oldbank = await _uow.Banks.Query()
                    .Where(s => s.BankId == bankId)
                    .Include(s => s.BankDepartaments)
                    .FirstOrDefaultAsync();
                if (oldbank == null)
                    throw new Exception($"Не удалось найти сущность");
                if (oldbank.BankDepartaments.Count != 0)
                {
                    throw new Exception($"Остались привязанные отделы");
                }

                _uow.Banks.DeleteById(bankId);
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
