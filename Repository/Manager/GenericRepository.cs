﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Farhad_Apro.Repository.Interface;

namespace Farhad_Apro.Repository.Manager
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext db;
        public GenericRepository(DbContext dbContext)
        {
            db = dbContext;
            //db = dbContext;
        }

        protected DbSet<T> Table
        {
            get
            {
                return db.Set<T>();

            }
        }

        public bool Add(T entity)
        {
            Table.Add(entity);
            return db.SaveChanges() > 0;

        }

        public bool Add(ICollection<T> entities)
        {
            Table.AddRange(entities);
            return db.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            Table.Remove(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(ICollection<T> entities)
        {
            Table.RemoveRange(entities);
            return db.SaveChanges() > 0;
        }

        public ICollection<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return includes
                .Aggregate(
                    Table.AsNoTracking().AsQueryable(),
                    (current, include) => current.Include(include),
                    c => c.Where(predicate)
                ).ToList();
        }

        public ICollection<T> GetAll(params Expression<Func<T, object>>[] include)
        {
            return include
                .Aggregate(
                    Table.AsNoTracking().AsQueryable(),
                    (current, includes) => current.Include(includes)
                ).ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return includes
                .Aggregate(
                    Table.AsNoTracking().AsQueryable(),
                    (current, include) => current.Include(include),
                    c => c.FirstOrDefault(predicate)
                );
        }

        public bool Update(T entity)
        {
            Table.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}