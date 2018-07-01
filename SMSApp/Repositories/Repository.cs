using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.Repositories
{
    /// <summary>
    /// Implementation of repository pattern for our application
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext mContext;

        public Repository(DbContext context)
        {
            mContext = context;
        }

        public void Add(TEntity value)
        {
            mContext.Set<TEntity>().Add(value);
        }

        public void AddRange(ICollection<TEntity> entities)
        {
            mContext.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return mContext.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity Get(int ID)
        {
            return mContext.Set<TEntity>().Find(ID);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return mContext.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            mContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(ICollection<TEntity> entities)
        {
            mContext.Set<TEntity>().RemoveRange(entities);
        }
    }
}
