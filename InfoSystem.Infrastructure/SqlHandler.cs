using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.Infrastructure.DataBase.Context;
using ModelExtensions = Microsoft.EntityFrameworkCore.Metadata.Internal.ModelExtensions;
using InfoSystem.Core.Entities.Basic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Attribute = InfoSystem.Core.Entities.Basic.Attribute;

namespace InfoSystem.Infrastructure
{
    internal class SqlHandler
    {
        internal SqlHandler(InfoSystemDbContext context)
        {
            _context = context;
        }

        internal void AddDisplayAttribute(string typeName, string newDisplayValue)
        {
            var sqlQuery = SqlOptions.GenerateInsertIntoAttributesScript(typeName,
                "display",
                newDisplayValue);
            _context.Database.ExecuteSqlCommand(new RawSqlString(sqlQuery));
            _context.SaveChanges();
        }

        internal bool CheckIfDisplayAttributeIsSet(string typeName)
        {
            var selectScript = SqlOptions.GenerateSelectScript(typeName + "attributes");
            new SqlHandler(_context).ManageQueryType(typeof(Attribute));
            var properties = _context.Query<Attribute>().FromSql(selectScript).ToArray();

            return properties.Any() && properties.Any(property => property.Key == "display");
        }

        internal IEnumerable<Attribute> GetTypeAttributesByName(string typeName)
        {
            ManageQueryType(typeof(Attribute));
            var query = SqlOptions.GenerateSelectScript(typeName + "attributes");
            return _context.Query<Attribute>().FromSql(query);
        }

        internal IEnumerable<Property> GetTypePropertiesByName(string typeName)
        {
            ManageQueryType(typeof(Property));
            var query = SqlOptions.GenerateSelectScript(typeName);
            return _context.Query<Property>().FromSql(query);
        }

        internal Property InsertRequiredProperty(string typeName, string requiredAttributeValue,
            string requiredPropertyName,
            EntityEntry<Entity> entityEntry)
        {
            var newProperty = new Property(requiredPropertyName, requiredAttributeValue, entityEntry.Entity.TypeId,
                entityEntry.Entity.Id);
            var sqlQuery = SqlOptions.GenerateInsertIntoScript(typeName, newProperty);
            _context.Database.ExecuteSqlCommand(new RawSqlString(sqlQuery));
            _context.SaveChanges();
            return newProperty;
        }

        private void ManageQueryType(Type type)
        {
            if (ModelDoesntHaveQueryType(type.FullName))
                ModelExtensions.AsModel(_context.Model).AddQueryType(type);
        }

        private bool ModelDoesntHaveQueryType(string fullTypeName) => !_context.Model.GetEntityTypes().Any(type =>
            type.IsQueryType && type.Name == fullTypeName);

        private readonly InfoSystemDbContext _context;
    }
}