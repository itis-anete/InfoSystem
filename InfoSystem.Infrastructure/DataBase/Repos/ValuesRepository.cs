using System.Collections.Generic;
using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
    public class ValuesRepository : IValuesRepository
    {
        private readonly InfoSystemDbContext _context;
        
        public ValuesRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }
        
        public void Add(Values receivedObj)
        {
            _context.Values.Add(receivedObj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Values.Remove(_context.Values.Find(id));
        }

        public IEnumerable<Values> Get()
        {
            return _context.Values;
        }

        public Values Get(int id)
        {
            return _context.Values.Find(id);
        }
    }
}