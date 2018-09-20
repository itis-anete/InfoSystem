using System;
using InfoSystem.App.DataBase.Context;
using InfoSystem.App.DataBase.Repos;
using InfoSystem.App.DataBase.ReposInterfaces;
using Microsoft.EntityFrameworkCore;

namespace InfoSystem.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepos => _userRepos;
        
        private bool isDisposed = false;
        private InfoSystemDbContext _context;
        private IUserRepository _userRepos;
        
        public UnitOfWork(string connectionString)
        {
            var options = new DbContextOptionsBuilder<InfoSystemDbContext>();
            options.UseSqlServer(connectionString);
            _context = new InfoSystemDbContext(options.Options);
            _userRepos = new UserRepository(_context); // Recreates every time?
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