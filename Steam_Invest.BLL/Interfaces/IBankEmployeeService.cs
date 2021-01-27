using Steam_Invest.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Invest.BLL.Interfaces
{
    public interface IBankEmployeeService
    {
        Task<BankEmployeeViewModel> GetBankEmployee(int employeeId);
        Task CreateEmployee(int departamentId, BankEmployeeDTO model);
        Task UpdateEmployee(int employeeId, BankEmployeeDTO model);
        Task DeleteEmployee(int employeeId);
    }
}
