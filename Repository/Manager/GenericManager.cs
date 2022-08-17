using System;
using System.Collections.Generic;
using Farhad_Apro.Repository.Interface;

namespace Farhad_Apro.Repository.Manager
{
    public class GenericManager<T> : IGenericManager<T> where T : class
    {
        private IGenericRepository<T> _repository;
        public GenericManager(IGenericRepository<T> common)
        {
            _repository = common;
        }


        public bool Add(T entity)
        {
            return _repository.Add(entity);
        }

        public bool Add(ICollection<T> entity)
        {
            return _repository.Add(entity);
        }

        public bool Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        public bool Delete(ICollection<T> entity)
        {
            return _repository.Delete(entity);
        }

        public ICollection<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        {
            return _repository.Get(predicate, includes);
        }

        public ICollection<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] include)
        {
            return _repository.GetAll(include);
        }

        public T GetFirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        {
            return _repository.GetFirstOrDefault(predicate, includes);
        }

        public bool Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}