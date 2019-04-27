using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
    public class EntityRepository
    {
        private readonly InfoSystemDbContext _context;

        public EntityRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public Entity Add(int typeId, string requiredAttributeValue)
        {
            var newEntity = new Entity();
            EntityType type;
            var typeName = _context.Types.FirstOrDefault(x => x.Id == typeId).Name;
            try
            {
                typeName = typeName.ToLower();
                type = _context.Types.FirstOrDefault(t => t.Name == typeName) ??
                       throw new ArgumentException("No such type found in db");
                newEntity.TypeId = type.Id;
                newEntity.Display = requiredAttributeValue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

            try
            {
                var entityEntry = AddEntityToDatabase(newEntity);
                var newProperty = AddRequiredPropertyAndReturnItFromDb(typeName, requiredAttributeValue,
                    type.RequiredProperty, entityEntry);

                var handler = new SqlHandler(_context);
                if (!handler.CheckIfDisplayAttributeIsSet(typeName))
                    handler.AddDisplayAttribute(typeName, newProperty.Value);

                return entityEntry.Entity;
            }
            catch (Exception e)
            {
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

        public Entity GetById(int id) => _context.Entities.Find(id);

        public IEnumerable<Entity> GetByTypeId(int typeId) =>
            _context.Entities.Where(e => e.TypeId == typeId);

        public IEnumerable<Entity> GetByTypeName(string typeName)
        {
            var type = _context.Types.FirstOrDefault(t => t.Name == typeName);
            var propertyRepository = new PropertyRepository(_context);
            var propertyName = propertyRepository.GetAttributeValue(typeName, "display");
            var entities = _context.Entities.Where(e => e.TypeId == type.Id);

            foreach (var entity in entities)
                entity.Display = propertyRepository.GetByPropertyName(propertyName, typeName, entity.Id).Value;

            return entities;
        }

        public IEnumerable<Dictionary<string, string>> GetMenu()
        {
            var s = new Stopwatch();
            s.Start();
            var type = _context.Types.FirstOrDefault(t => t.Name == "menuitem") 
                       ?? throw new ArgumentException("menuitem doesn't exist in database");
            var entities = _context.Entities.Where(e => e.TypeId == type.Id);
            
            var entitiesProperties = new List<Dictionary<string, string>>();
            var propertyRepository = new PropertyRepository(_context);
            
            foreach (var entity in entities)
            {
                var dict = new Dictionary<string, string>();
                var props = propertyRepository.GetByEntityId(entity.Id, type.Id).ToList();
                props.ForEach(x => dict.Add(x.Key, x.Value));
                entitiesProperties.Add(dict);
            }

            
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
            return entitiesProperties;
        }
        
        private EntityEntry<Entity> AddEntityToDatabase(Entity newEntity)
        {
            var entityEntry = _context.Entities.Add(newEntity);
            _context.SaveChanges();
            return entityEntry;
        }

        private Property AddRequiredPropertyAndReturnItFromDb(string typeName, string requiredAttributeValue,
            string requiredPropertyName,
            EntityEntry<Entity> entityEntry)
        {
            var handler = new SqlHandler(_context);
            var newProperty =
                handler.InsertRequiredProperty(typeName, requiredAttributeValue, requiredPropertyName, entityEntry);
            return handler.GetTypePropertiesByName(typeName)
                       .FirstOrDefault(property => property.Key == newProperty.Key 
                                                   && property.EntityId == newProperty.EntityId)
                   ?? throw new ArgumentNullException();
        }
    }
}