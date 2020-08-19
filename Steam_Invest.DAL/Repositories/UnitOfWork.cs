using Steam_Invest.DAL.EF;
using Steam_Invest.DAL.Entities;
using Steam_Invest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Steam_InvestContext _context;

        #region Fields

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

        public IGenericRepository<PersonInfo> PersonInfo
            => _personInfo ?? (_personInfo = new GenericRepository<PersonInfo>(_context));

        public IGenericRepository<Portfolio> Portfolios
            => _portfolio ?? (_portfolio = new GenericRepository<Portfolio>(_context));

        public IGenericRepository<Item> Items
            => _item ?? (_item = new GenericRepository<Item>(_context));

        public IGenericRepository<Game> Games
            => _game ?? (_game = new GenericRepository<Game>(_context));

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
