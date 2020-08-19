using Steam_Invest.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<PersonInfo> PersonInfo { get; }
        IGenericRepository<Portfolio> Portfolios { get; }
        IGenericRepository<Item> Items { get; }
        IGenericRepository<Game> Games { get; }
    }
}
