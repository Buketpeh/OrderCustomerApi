using BasketApplication.Data.Context;
using OrderApi.Data.Repositories;
using OrderCustomerApi.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
           return new Repository<T>(_context);
        }
        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ) { throw; }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool dispoing)
        {
            if (!this.disposed)
            {
                if (dispoing)
                    _context.Dispose();
            }
            this.disposed = true;
        }




    }
}
