using Microsoft.AspNet.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Invest.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateNew(TEntity entity, TEntity newEntity);

        TEntity AddR(TEntity entity);
        TEntity UpdateR(TEntity entity);

        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        void DeleteById(object id);
        void DeletePredicate(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetByIdAsync(object id, params Expression<Func<TEntity, object>>[] navigationProperties);
        TEntity GetById(object id, params Expression<Func<TEntity, object>>[] navigationProperties);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties);
        TEntity Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties);

        Task<IList<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] navigationProperties);
        IList<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties);
        IList<TEntity> GetAll(ODataQueryOptions<TEntity> options, params Expression<Func<TEntity, object>>[] navigationProperties);

        IList<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties);
        IList<TEntity> GetManyT(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties);
        Task<IList<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties);
        IList<TEntity> GetMany(ODataQueryOptions<TEntity> options, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties);

        IQueryable<TEntity> GetManyQuery(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties);

        void UpdateWithoutAttach(TEntity entity);

        IQueryable<TEntity> Query();
    }
}
