using Steam_Invest.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Invest.BLL.Interfaces
{
    public interface IBankDepartamentService
    {
        Task<BankDepartamentViewModel> GetBankDepartament(int departamentId);
        Task CreateDepartament(int bankId, BankDepartamentDTO model);
        Task UpdateDepartament(int departamentId, BankDepartamentDTO model);
        Task DeleteDepartament(int departamentId);
    }
}
