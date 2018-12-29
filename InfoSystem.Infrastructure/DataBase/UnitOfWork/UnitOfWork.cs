using System;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.DataBase.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepos => _userRepos ?? (_userRepos = new UserRepository(_context));
        public IMarketRepository MarketRepos => _marketRepos ?? (_marketRepos = new MarketRepository(_context));
        public IMarketProductRepository MarketProductRepos =>
            _marketProductRepos ?? (_marketProductRepos = new MarketProductRepository(_context));
        public IProductRepository ProductRepos => _productRepos ?? (_productRepos = new ProductRepository(_context));
        public IEntityRepository EntityRepos => _entityRepos ?? (_entityRepos = new EntityRepository(_context));
        public IPropertiesRepository PropertiesRepos => _propertiesRepos ?? (_propertiesRepos = new PropertiesRepository(_context));
        public IValuesRepository ValuesRepos => _valuesRepos ?? (_valuesRepos = new ValuesRepository(_context));

        private bool isDisposed = false;
        private readonly InfoSystemDbContext _context;

        private IUserRepository _userRepos;
        private IMarketRepository _marketRepos;
        private IMarketProductRepository _marketProductRepos;
        private IProductRepository _productRepos;
        private IEntityRepository _entityRepos;
        private IPropertiesRepository _propertiesRepos;
        private IValuesRepository _valuesRepos;

        public UnitOfWork()
        {
//            var options = new DbContextOptionsBuilder<InfoSystemDbContext>();
            _context = new InfoSystemDbContext();
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