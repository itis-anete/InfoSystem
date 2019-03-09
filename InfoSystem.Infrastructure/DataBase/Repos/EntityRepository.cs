using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
    public class EntityRepository
    {

        public EntityRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(string typeName)
        {
            var newEntity = new Entity();
            var type = _context.Types.FirstOrDefault(t => t.Name == typeName);
            if (type == null)
            {
                var newType = new EntityType {Name = typeName};
                _context.Types.Add(newType);
                var receivedType = _context.Types.FirstOrDefault(t => t.Name == typeName);
                newEntity.TypeId = receivedType?.Id ?? 1;
            }
            else
                newEntity.TypeId = type.Id;

            _context.Entities.Add(newEntity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Entities.Remove(_context.Entities.Find(id));
        }

        public IEnumerable<Entity> Get() => _context.Entities;

        public Entity GetById(int id)
        {
            return _context.Entities.Find(id);
        }

        private readonly InfoSystemDbContext _context;
    }
}