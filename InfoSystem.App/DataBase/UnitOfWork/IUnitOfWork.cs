using System;
using InfoSystem.App.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepos { get; }
        void Save();
    }
}