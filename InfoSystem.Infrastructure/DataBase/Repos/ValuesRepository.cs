using System.Collections.Generic;
using InfoSystem.Core.Entities;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
    public class ValuesRepository : IBaseRepository<Value>
    {
        private readonly InfoSystemDbContext _context;

        public ValuesRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(Value receivedObj)
        {
            _context.Values.Add(receivedObj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Values.Remove(_context.Values.Find(id));
        }

        public IEnumerable<Value> Get()
        {
            return _context.Values;
        }

        public Value GetById(int id)
        {
            return _context.Values.Find(id);
        }
    }
}