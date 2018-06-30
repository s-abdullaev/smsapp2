using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SMSApp
{
    /// <summary>
    /// Implementation of repository pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T:class
    {

        /// <summary>
        /// Gets all data />
        /// </summary>
        /// <returns></returns>
        T Get(int ID);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Add new value t
        /// </summary>
        /// <param name="value"></param>
        void Add(T value);

        /// <summary>
        /// Find with pridicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> Find(Expression<Func<T,bool>> predicate);
    }
}
