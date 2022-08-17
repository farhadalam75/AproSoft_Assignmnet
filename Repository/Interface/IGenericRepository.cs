using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Farhad_Apro.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        bool Add(T entity);
        bool Add(ICollection<T> entities);

        bool Update(T entity);

        bool Delete(T entity);
        bool Delete(ICollection<T> entities);

        /// <summary>
        /// all table data
        /// </summary>
        ICollection<T> GetAll(params Expression<Func<T, object>>[] include);
        /// <summary>
        /// get data by Lamda expression
        /// </summary>
        ICollection<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        /// <summary>
        /// get single data
        /// </summary>
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    }
}