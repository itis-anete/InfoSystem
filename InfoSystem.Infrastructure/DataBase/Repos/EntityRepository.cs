using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

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
                int newId;
                try
                {
                    newId = _context.Types.Max(t => t.Id) + 1;
                }
                catch (Exception e)
                {
                    newId = 1;
                }
                _context.Types.Add(new EntityType { Id = newId, Name = receivedObj.Name});
                receivedObj.TypeId = newId;
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