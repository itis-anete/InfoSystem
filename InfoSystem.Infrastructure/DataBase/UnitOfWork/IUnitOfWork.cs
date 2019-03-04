//using System;
//using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
//
//namespace InfoSystem.Infrastructure.DataBase.UnitOfWork
//{
//    public interface IUnitOfWork : IDisposable
//    {
//        IUserRepository UserRepos { get; }
//        IMarketRepository MarketRepos { get; }
//        IMarketProductRepository MarketProductRepos { get; }
//        IProductRepository ProductRepos { get; }
//        IEntityRepository EntityRepos { get; }
//        IPropertiesRepository PropertiesRepos { get; }
//        IValuesRepository ValuesRepos { get; }
//        
//        void Save();
//    }
//}