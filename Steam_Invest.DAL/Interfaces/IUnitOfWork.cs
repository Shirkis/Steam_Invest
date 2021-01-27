using Steam_Invest.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Steam_Invest.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<AspNetUser> AspNetUsers { get; }
        //IGenericRepository<AspNetRole> AspNetRoles { get; }
        //IGenericRepository<AspNetUserRole> AspNetUserRoles { get; }
        IGenericRepository<PersonInfo> PersonInfo { get; }
        IGenericRepository<Portfolio> Portfolios { get; }
        IGenericRepository<Item> Items { get; }
        IGenericRepository<Game> Games { get; }
        IGenericRepository<Currency> Currencies { get; }
        IGenericRepository<Purchase> Purchases { get; }
        IGenericRepository<Bank> Banks { get; }
        IGenericRepository<BankDepartament> BankDepartaments { get; }
        IGenericRepository<BankEmployee> BankEmployees { get; }

        #region Methods
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        #endregion
    }
}
