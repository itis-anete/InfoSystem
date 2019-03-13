using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
    public class EntityRepository : IEntityRepository
    {
        public EntityRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public Entity Add(string typeName)
        {
            var newEntity = new Entity();
            try
            {
                var type = _context.Types.FirstOrDefault(t => t.Name == typeName);
                if (type == null)
                {
                    var typeRepository = new TypeRepository(new InfoSystemDbContext());
                    var newType = typeRepository.Add(typeName);
                    newEntity.TypeId = newType?.Id ?? 1;
                }
                else
                    newEntity.TypeId = type.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine("TYPES FAILED");
                Console.WriteLine(e);
                return null;
            }

            try
            {
                var entityEntry = _context.Entities.Add(newEntity);
                _context.SaveChanges();
                return entityEntry.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine("ENTITIES FAILED");
                Console.WriteLine(e);
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _context.Entities.Remove(_context.Entities.Find(id));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public IEnumerable<Entity> Get() => _context.Entities;

        public Entity GetById(int id) => _context.Entities.Find(id);

        public IEnumerable<Entity> GetByTypeId(int typeId) =>
            _context.Entities.Where(e => e.TypeId == typeId);

        private readonly InfoSystemDbContext _context;
    }
}