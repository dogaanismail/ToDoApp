using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ToDoApp.Core.Entities;

namespace ToDoApp.Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Returns a list of T object. 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<T> GetList(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Returns a single object of T.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Creates an entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

    }
}
