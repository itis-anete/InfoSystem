using System;
using InfoSystem.App.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepos { get; }
        IMarketRepository MarketRepos { get; }
        IMarketProductRepository MarketProductRepos { get; }
        IProductRepository ProductRepos { get; }
        
        void Save();
    }
}