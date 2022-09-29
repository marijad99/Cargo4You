﻿using System;
using System.Linq;
using Cargo4You.Contracts;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
//using Cargo4You.Core;
//using Cargo4You.BusinessObjects;

namespace Ahlics.DAL.SQL
{
    public class SqlGenericRepository<TEntity, TContext> : IGenericRepository<TEntity> where TEntity : class where TContext : IDbContext
    {
        internal IDbContext context;  
        internal DbSet<TEntity> dbSet;

        public SqlGenericRepository(IDbContext context)
        {
            this.context = context;      
            this.dbSet = context.Set<TEntity>();
        }

        public object ReturnContext(object obj)
        {
            context.Entry(obj).State = EntityState.Detached;
            context.Entry(obj).State = EntityState.Added;
            return obj;
        }

        public object SetObjectStateToAdded(object obj)
        {
            context.Entry(obj).State = EntityState.Added;
            return obj;
        }

        public object SetObjectStateToDetached(object obj)
        {
            context.Entry(obj).State = EntityState.Detached;
            return obj;
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IQueryable<TEntity> GetAsQueryable(
      Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = dbSet;
        
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.Count();
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Gets the by identifier.
        /// !! Custom modif
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns></returns>
        public virtual TEntity GetByID(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entitiesToDelete)
        {
            foreach (var entity in entitiesToDelete)
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
            }

            dbSet.RemoveRange(entitiesToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            var entry = context.Entry(entityToUpdate);

            entry.State = EntityState.Detached;

            entry.State = EntityState.Modified;
        }

        public virtual void UpdateWithRelatedEntities(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public virtual IEnumerable<TEntity> CopyEntityDetached(TEntity newTEntity,
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
             (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.AsNoTracking().Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IEnumerable<TEntity> CopyEntityAttached(TEntity newTEntity,
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
             (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public object MarkObjectAsAdded(object obj)
        {
            context.Entry(obj).State = EntityState.Added;
            return obj;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public bool Exists(
             Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;

            var result = query.Any(filter);

            return result;
        }

        public virtual void DeleteRange(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            dbSet.RemoveRange(query);
        }
    }
}
