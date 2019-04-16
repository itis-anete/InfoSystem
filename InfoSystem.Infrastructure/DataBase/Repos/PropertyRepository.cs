using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.Infrastructure.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using Property = InfoSystem.Core.Entities.Basic.Property;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class PropertyRepository
	{
		private readonly InfoSystemDbContext _context;

		public PropertyRepository(InfoSystemDbContext context)
		{
			_context = context;
		}

		public Property Add(Property newProperty)
		{
			try
			{
				var typeName = _context.Types.Find(newProperty.TypeId)?.Name;
				var sql = SqlOptions.GenerateInsertIntoScript(typeName, newProperty);
				_context.Database.ExecuteSqlCommand(sql);

				var property = new SqlHandler(_context).GetTypePropertiesByName(typeName)
					.FirstOrDefault(a =>
						a.Key == newProperty.Key &&
						a.TypeId == newProperty.TypeId &&
						a.EntityId == newProperty.EntityId &&
						a.Value == newProperty.Value);

				if (property.IsComplex)
					SetDisplayComplexValue(property);

				return property;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		public bool Delete(string typeName, int attributeId)
		{
			try
			{
				typeName = typeName.ToLower();
				var sql = SqlOptions.GenerateDeleteScript(typeName, attributeId);
				_context.Database.ExecuteSqlCommand(sql);
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return false;
			}
		}

		public string GetAttributeValue(string typeName, string attributeName)
		{
			var attribute = new SqlHandler(_context).GetTypeAttributesByName(typeName)
				.FirstOrDefault(a => a.Key == attributeName);
			if (attribute == null)
				throw new ArgumentException($"No value have been set for {attributeName}");
			return attribute.Value;
		}

		public IEnumerable<Property> GetByEntityId(int entityId, int typeId) =>
			GetTypePropertiesById(typeId).Where(a => a.EntityId == entityId);

		public Property GetByPropertyName(string propertyName, string typeName, int entityId) =>
			new SqlHandler(_context).GetTypePropertiesByName(typeName)
				.FirstOrDefault(p => p.EntityId == entityId && p.Key == propertyName);

		public IEnumerable<Property> GetByTypeName(int entityId, string typeName)
		{
			var properties = new SqlHandler(_context).GetTypePropertiesByName(typeName)
				.Where(a => a.EntityId == entityId);
			var propertiesList = properties.ToList();
			foreach (var property in propertiesList)
			{
				if (property.IsComplex)
					SetDisplayComplexValue(property);
			}

			return propertiesList;
		}

		public IEnumerable<Property> GetTypePropertiesById(int typeId)
		{
			var typeName = _context.Types.Find(typeId)?.Name;
			return new SqlHandler(_context).GetTypePropertiesByName(typeName);
		}

		public void SetDisplayComplexValue(Property property)
		{
			var complexPropertyTypeName = property.Key.Substring(8);
			var propertyName = GetAttributeValue(complexPropertyTypeName, "display");
			var propertyValue = GetByPropertyName(propertyName, complexPropertyTypeName, int.Parse(property.Value))
				.Value;
			property.DisplayComplexValue = propertyValue;
		}

		public Property Update(string typeName, string newValue, int attributeId)
		{
			try
			{
				typeName = typeName.ToLower();
				var sql = SqlOptions.GenerateUpdateScript(typeName, newValue, attributeId);
				_context.Database.ExecuteSqlCommand(sql);

				return new SqlHandler(_context).GetTypePropertiesByName(typeName)
					.FirstOrDefault(a => a.Id == attributeId);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}
	}
}