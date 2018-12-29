using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly InfoSystemDbContext _context;

        public UserRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(User newUser)
        {
            //if (_context.Users.Any(user => user.Username == newUser.Username))
            //    throw new ArgumentException();
            _context.Users.AddAsync(newUser);
        }

        public void Delete(int id) => _context.Users.Remove(_context.Users.Find(id));
        public bool AuthoriseUser(User receivedData) => _context.Users.Contains(receivedData); // not save enough
        public IEnumerable<User> Get() => _context.Users.OrderBy(u => u);
        public User Get(int id) => _context.Users.Find(id);
    }
}