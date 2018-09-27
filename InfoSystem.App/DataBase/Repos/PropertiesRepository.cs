using System.Collections.Generic;
using InfoSystem.App.DataBase.Context;
using InfoSystem.App.DataBase.ReposInterfaces;
using InfoSystem.Infrastructure.Entities;
using InfoSystem.Infrastructure.UnitOfWork;

namespace InfoSystem.App.DataBase.Repos
{
    public class PropertiesRepository : IPropertiesRepository
    {
        private readonly InfoSystemDbContext _context;
        
        public PropertiesRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }
        
        public void Add(Properties receivedObj)
        {
            _context.Properties.Add(receivedObj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Properties.Remove(_context.Properties.Find(id));
        }

        public IEnumerable<Properties> Get()
        {
            return _context.Properties;
        }

        public Properties Get(int id)
        {
            return _context.Properties.Find(id);
        }
    }
}