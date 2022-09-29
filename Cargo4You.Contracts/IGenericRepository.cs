using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query;
//using Cargo4You.BusinessObjects;
using System.Threading.Tasks;

namespace Cargo4You.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void DeleteRange(IEnumerable<TEntity> entitiesToDelete);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        IQueryable<TEntity> GetAsQueryable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        TEntity GetByID(object id);

        TEntity GetByID(params object[] keyValues);

        void Insert(TEntity entity);

        void InsertRange(IEnumerable<TEntity> entities);

        void Update(TEntity entityToUpdate);

        void UpdateWithRelatedEntities(TEntity entity);

        object SetObjectStateToDetached(object obj);
        object SetObjectStateToAdded(object obj);

        bool Exists(Expression<Func<TEntity, bool>> filter = null);

        void DeleteRange(Expression<Func<TEntity, bool>> filter = null);
       
    }
}
