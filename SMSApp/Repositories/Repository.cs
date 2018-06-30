using SMSApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp
{
    /// <summary>
    /// Implementation of repository pattern for our application
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext mContext;

        public Repository(DbContext context)
        {
            mContext = context;
        }

        public void Add(T value)
        {
            mContext.Set<T>().Add(value);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return mContext.Set<T>().Where(predicate);
        }

        public T Get(int ID)
        {
            return mContext.Set<T>().Find(ID);
        }

        public IEnumerable<T> GetAll()
        {
            return mContext.Set<T>().ToList();
        }
    }
}
