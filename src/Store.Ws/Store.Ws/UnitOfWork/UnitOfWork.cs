using Store.Data.Models;
using StoreWS.Repository;
using System;

namespace StoreWS.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StoreContext _context = new StoreContext();

        public UnitOfWork()
        {
            _context.Configuration.LazyLoadingEnabled = true;

            ClientRepository = new ClientRepository(_context);
            OrderRepository = new OrderRepository(_context);
            ProductRepository = new ProductRepository(_context);
        }

        public IClientRepository ClientRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }

        private bool _disposed;

        public void Dispose()
        {
            Clear(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        private void Clear(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        ~UnitOfWork()
        {
            Clear(false);
        }
    }
}