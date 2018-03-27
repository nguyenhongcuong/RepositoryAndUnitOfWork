using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Demo.Models;

namespace Demo.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbSet = context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbSet.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable<T>();
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
