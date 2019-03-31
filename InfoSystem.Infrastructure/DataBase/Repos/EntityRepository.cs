using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Attribute = InfoSystem.Core.Entities.Basic.Attribute;
using ModelExtensions = Microsoft.EntityFrameworkCore.Metadata.Internal.ModelExtensions;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
    public class EntityRepository : IEntityRepository
    {
        public EntityRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public Entity Add(string typeName, string requiredAttributeValue)
        {
            var newEntity = new Entity();
            EntityType type;
            try
            {
                typeName = typeName.ToLower();
                type = _context.Types.FirstOrDefault(t => t.Name == typeName) ??
                       throw new ArgumentException("No such type found in db");
                newEntity.TypeId = type.Id;
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

                if (!CheckIfDisplayAttributeIsSet(typeName))
                    AddDisplayAttribute(typeName, newProperty, type);

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

        private void AddDisplayAttribute(string typeName, Property newProperty, EntityType type)
        {
            var sqlQuery = SqlOptions.GenerateInsertIntoAttributesScript(typeName,
                "display",
                newProperty.Key);
            _context.Database.ExecuteSqlCommand(new RawSqlString(sqlQuery));
            _context.SaveChanges();
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
            var newProperty = new Property(requiredPropertyName, requiredAttributeValue, entityEntry.Entity.TypeId,
                entityEntry.Entity.Id);
            var sqlQuery = SqlOptions.GenerateInsertIntoScript(typeName, newProperty);
            _context.Database.ExecuteSqlCommand(new RawSqlString(sqlQuery));
            _context.SaveChanges();
            return GetTypePropertiesByName(typeName)
                       .FirstOrDefault(property =>
                           property.Key == newProperty.Key && property.EntityId == newProperty.EntityId)
                   ?? throw new ArgumentNullException();
        }

        private bool CheckIfDisplayAttributeIsSet(string typeName)
        {
            var selectScript = SqlOptions.GenerateSelectScript(typeName + "attributes");
            ManageQueryType(typeof(Attribute));
            var properties = _context.Query<Attribute>().FromSql(selectScript).ToArray();

            return properties.Any() && properties.Any(property => property.Key == "display");
        }

        private IEnumerable<Property> GetTypePropertiesByName(string typeName)
        {
            ManageQueryType(typeof(Property));
            var query = SqlOptions.GenerateSelectScript(typeName);
            return _context.Query<Property>().FromSql(query);
        }

        private void ManageQueryType(Type type)
        {
            if (ModelDoesntHaveQueryType(type.FullName))
                ModelExtensions.AsModel(_context.Model).AddQueryType(type);
        }

        private bool ModelDoesntHaveQueryType(string fullTypeName) => !_context.Model.GetEntityTypes().Any(type =>
            type.IsQueryType && type.Name == fullTypeName);
    }
}