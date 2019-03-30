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
                typeName = typeName.ToLower();
                var type = _context.Types.FirstOrDefault(t => t.Name == typeName) ??
                           throw new ArgumentException("No such type found in db");
                newEntity.TypeId = type.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine("RETARD ALERT! TYPES FAILED");
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
                Console.WriteLine("RETARD ALERT! ENTITIES FAILED");
                Console.WriteLine(e);
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _context.Entities.Remove(_context.Entities.Find(id));
                _context.SaveChanges();
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

        public IEnumerable<Entity> GetByTypeName(string typeName)
        {
            var type = _context.Types.FirstOrDefault(t => t.Name == typeName);
            return _context.Entities.Where(e => e.TypeId == type.Id);
        }

        private readonly InfoSystemDbContext _context;
    }
}