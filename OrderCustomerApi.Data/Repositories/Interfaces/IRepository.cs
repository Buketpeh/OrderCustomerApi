using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data.Repositories
{
    public interface IRepository<T>  where T : class
    {
        IQueryable GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(Guid guid);
        T Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Guid guid);
    }
}