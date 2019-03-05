using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
    public class EntityRepository //: IBaseRepository<Entity>
    {

        public EntityRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(Entity receivedObj)
        {
            var type = _context.Types.FirstOrDefault(t => t.Name == receivedObj.Name);
            if (type == null)
            {
                _context.Types.Add(new EntityType { Name = receivedObj.Name});
                _context.SaveChanges();
                receivedObj.TypeId = _context.Types.First(t => t.Name == receivedObj.Name).Id;
            }
            else
                receivedObj.TypeId = type.Id;
            
            _context.Entities.Add(receivedObj);
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