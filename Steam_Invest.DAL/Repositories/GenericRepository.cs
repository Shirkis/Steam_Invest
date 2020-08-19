using Microsoft.AspNet.OData.Query;
using Microsoft.EntityFrameworkCore;
using Steam_Invest.DAL.EF;
using Steam_Invest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Invest.DAL.Repositories
{
    internal class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private Steam_InvestContext _context;
        private DbSet<TEntity> _set;

        internal GenericRepository(Steam_InvestContext context)
        {
            _context = context;
        }

        protected DbSet<TEntity> dbSet
        {
            get { return _set ?? (_set = _context.Set<TEntity>()); }
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> objects = dbSet.Where(predicate).AsEnumerable();
            if (objects.Count() == 0)
            {
                return;
            }
            dbSet.RemoveRange(objects);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteById(object id)
        {
            var c = dbSet.Find(id);
            if (c == null)
            {
                return;
            }
            dbSet.Remove(c);
        }

        public async Task<IList<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            List<TEntity> list;

            IQueryable<TEntity> dbQuery = dbSet;

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            list = await dbQuery
                .AsNoTracking()
                .ToListAsync<TEntity>();

            return list;
        }

        public IList<TEntity> GetAll(ODataQueryOptions<TEntity> options, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> dbQuery = dbSet;

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            var temp = (IQueryable<TEntity>)options.ApplyTo(dbQuery);
            dbQuery = temp.AsNoTracking();

            return dbQuery.ToList();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            TEntity res;

            IQueryable<TEntity> dbQuery = dbSet;

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            res = await dbQuery
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);

            return res;
        }
        public TEntity Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            TEntity res;

            IQueryable<TEntity> dbQuery = dbSet;

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            res = dbQuery
                .AsNoTracking()
                .FirstOrDefault(predicate);

            return res;
        }

        [Obsolete("Does not work correctly sometimes")]
        public async Task<TEntity> GetByIdAsync(object id, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            return await dbSet.FindAsync(id);
        }

        public IList<TEntity> GetMany(ODataQueryOptions<TEntity> options, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> dbQuery = dbSet;

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            var temp = (IQueryable<TEntity>)options.ApplyTo(dbQuery.Where(predicate));
            dbQuery = temp.AsNoTracking();

            return dbQuery.ToList();
        }

        public async Task<IList<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            List<TEntity> list;

            IQueryable<TEntity> dbQuery = dbSet;

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            list = await dbQuery
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync<TEntity>();

            return list;
        }

        public IList<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            List<TEntity> list;

            IQueryable<TEntity> dbQuery = dbSet;

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .Where(predicate.Compile())
                .ToList();

            return list;
        }

        public IList<TEntity> GetManyT(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            List<TEntity> list;

            IQueryable<TEntity> dbQuery = dbSet;

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            list = dbQuery
                .Where(predicate)
                .ToList<TEntity>();

            return list;
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        //???
        public TEntity GetById(object id, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            return dbSet.Find(id);
        }

        public IList<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            List<TEntity> list;

            IQueryable<TEntity> dbQuery = dbSet;

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .ToList<TEntity>();

            return list;
        }

        public TEntity AddR(TEntity entity)
        {
            var res = dbSet.Add(entity);
            return res.Entity;
        }

        public TEntity UpdateR(TEntity entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void UpdateNew(TEntity entity, TEntity newEntity)
        {
            _context.Entry(entity).CurrentValues.SetValues(newEntity);
        }

        public IQueryable<TEntity> GetManyQuery(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> list;

            IQueryable<TEntity> dbQuery = dbSet;

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .Where(predicate);
            return list;
        }

        public void DeletePredicate(Expression<Func<TEntity, bool>> predicate)
        {
            var item = dbSet.FirstOrDefault(predicate);
            if (item == null)
            {
                return;
            }
            dbSet.Remove(item);
        }

        public void UpdateWithoutAttach(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public IQueryable<TEntity> Query()
        {
            return dbSet;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }
    }
}
