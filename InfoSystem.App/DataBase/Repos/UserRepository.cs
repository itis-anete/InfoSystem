using System.Collections.Generic;
using InfoSystem.App.DataBase.Context;
using InfoSystem.App.DataBase.ReposInterfaces;
using InfoSystem.Infrastructure.Entities;

namespace InfoSystem.App.DataBase.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly InfoSystemDbContext _context;

        public UserRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }
        
        public void AddUser()
        {
            throw new System.NotImplementedException();
        }

        public bool AuthoriseUser()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }
    }
}