using System.Collections.Generic;
using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
    public class EntityRepository : IEntityRepository
    {
        private readonly InfoSystemDbContext _context;

        public EntityRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(Entity receivedObj)
        {
            _context.Entities.Add(receivedObj);
            foreach (var property in receivedObj.Properties)
            {
                _context.EntityProperties.Add(
                    new EntityProperty() {EntityId = receivedObj.Id, PropertyId = property.Id});
            }

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

        public Entity Get(int id)
        {
            return _context.Entities.Find(id);
        }
    }
}