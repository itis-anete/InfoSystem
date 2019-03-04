using System.Collections.Generic;
using InfoSystem.Core.Entities;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
    public class EntityRepository : IBaseRepository<Entity>
    {

        public EntityRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(Entity receivedObj)
        {
            _context.Entities.Add(receivedObj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Entities.Remove(_context.Entities.Find(id));
        }

        public IEnumerable<Entity> Get()
        {
            return _context.Entities;
        }

        public Entity GetById(int id)
        {
            return _context.Entities.Find(id);
        }

        private readonly InfoSystemDbContext _context;
    }
}