using OrderCustomerApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OrderCustomerApi.Data.Repositories.Interfaces;

namespace OrderApi.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IQueryable GetAll()
        {
            return _dbSet;
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        { 
            //To do: is deleted kontrolü
           return _dbSet.Where(predicate);
        }
        public T GetById(Guid guid)
        {
            return _dbSet.Find(guid);
        }
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }
       
        public void Add(T entity)
        {
           _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State=EntityState.Modified;
        }

        public void Delete(T entity)
        {
           _dbSet.Remove(entity);
        }
        public void Delete(Guid guid)
        {
            var entity = GetById(guid);
            if (entity == null) return;
            if (entity is IRecoverableEntity)
                (entity as IRecoverableEntity).IsDeleted = true;
            else
                _dbSet.Remove(entity);

        }
        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void GetDatabaseValues(T entity)
        {
             _dbSet.Entry(entity).GetDatabaseValues();
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            entities = entities.ToArray();
            if (typeof(IRecoverableEntity).IsAssignableFrom(typeof(T)))
            {
                foreach (var entity in entities)
                {
                    (entity as IRecoverableEntity).IsDeleted = true;
                }
            }
            else
                _dbSet.RemoveRange(entities);
        }




    }
}
