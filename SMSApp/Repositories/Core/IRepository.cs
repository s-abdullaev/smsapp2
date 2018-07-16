using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SMSApp.Repositories.Core
{
    /// <summary>
    /// Implementation of repository pattern
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity:class
    {

        /// <summary>
        /// Gets all data />
        /// </summary>
        /// <returns></returns>
        TEntity Get(int ID);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Add new value t
        /// </summary>
        /// <param name="value"></param>
        void Add(TEntity value);

        /// <summary>
        /// Ads the number of entities
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(ICollection<TEntity> entities);

        /// <summary>
        /// Removes the data 
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);

        /// <summary>
        /// Removes the number of entities
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(ICollection<TEntity> entities);

        /// <summary>
        /// Find with pridicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate);

    }
}
