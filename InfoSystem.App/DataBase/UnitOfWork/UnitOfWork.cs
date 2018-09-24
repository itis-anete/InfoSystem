using System;
using InfoSystem.App.DataBase.Context;
using InfoSystem.App.DataBase.Repos;
using InfoSystem.App.DataBase.ReposInterfaces;
using Microsoft.EntityFrameworkCore;

namespace InfoSystem.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepos => _userRepos ?? new UserRepository(_context);
        public IMarketRepository MarketRepos => _marketRepos ?? new MarketRepository(_context);
        public IMarketProductRepository MarketProductRepos =>
            _marketProductRepos ?? new MarketProductRepository(_context);
        public IProductRepository ProductRepos => _productRepos ?? new ProductRepository(_context);

        private bool isDisposed = false;
        private readonly InfoSystemDbContext _context;

        private IUserRepository _userRepos;
        private IMarketRepository _marketRepos;
        private IMarketProductRepository _marketProductRepos;
        private IProductRepository _productRepos;

        public UnitOfWork(string connectionString)
        {
            var options = new DbContextOptionsBuilder<InfoSystemDbContext>();
            options.UseSqlServer(connectionString);
            _context = new InfoSystemDbContext(options.Options);
        }

        #region IDisposableImplementation

        public virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                    _context.Dispose();
                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}