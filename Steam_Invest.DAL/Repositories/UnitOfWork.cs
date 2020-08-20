using Steam_Invest.DAL.EF;
using Steam_Invest.DAL.Entities;
using Steam_Invest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Invest.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Steam_InvestContext _context;

        #region Fields

        private IGenericRepository<AspNetUser> _aspNetUsers;
        private IGenericRepository<PersonInfo> _personInfo;
        private IGenericRepository<Portfolio> _portfolio;
        private IGenericRepository<Item> _item;
        private IGenericRepository<Game> _game;

        #endregion

        #region Constructors

        public UnitOfWork(Steam_InvestContext db)
        {
            _context = db;
        }

        #endregion

        #region IUnitOfWork Members

        public IGenericRepository<AspNetUser> AspNetUsers
            => _aspNetUsers ?? (_aspNetUsers = new GenericRepository<AspNetUser>(_context));
        public IGenericRepository<PersonInfo> PersonInfo
            => _personInfo ?? (_personInfo = new GenericRepository<PersonInfo>(_context));

        public IGenericRepository<Portfolio> Portfolios
            => _portfolio ?? (_portfolio = new GenericRepository<Portfolio>(_context));

        public IGenericRepository<Item> Items
            => _item ?? (_item = new GenericRepository<Item>(_context));

        public IGenericRepository<Game> Games
            => _game ?? (_game = new GenericRepository<Game>(_context));

        #endregion

        #region Methods
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region IDisposable Members

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
