using Steam_Invest.BLL.BankClasses;
using Steam_Invest.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Invest.BLL.Interfaces
{
    public interface IBankService
    {
        Task<List<BankDTO>> GetBanks();
        Task<BankClass> GetBankInContainer(int bankId);
        Task<BankViewModel> GetBank(int bankId);
        Task CreateBank(BankDTO model);
        Task UpdateBank(int bankId, BankDTO model);
        Task DeleteBank(int bankId);
    }
}
