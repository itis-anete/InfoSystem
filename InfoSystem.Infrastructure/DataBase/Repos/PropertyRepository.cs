using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Property = InfoSystem.Core.Entities.Basic.Property;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class PropertyRepository : IPropertyRepository
	{
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

				return GetTypeAttributesByName(typeName)
					.FirstOrDefault(a =>
						a.Key == newProperty.Key &&
						a.TypeId == newProperty.TypeId &&
						a.EntityId == newProperty.EntityId &&
						a.Value == newProperty.Value);
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

		public IEnumerable<Property> GetTypePropertiesById(int typeId)
		{
			var typeName = _context.Types.Find(typeId)?.Name;
			return GetTypeAttributesByName(typeName);
		}

		public IEnumerable<Property> GetByEntityId(int entityId, int typeId) =>
			GetTypePropertiesById(typeId).Where(a => a.EntityId == entityId);

		public IEnumerable<Property> GetByTypeName(int entityId, string typeName) =>
			GetTypeAttributesByName(typeName).Where(a => a.EntityId == entityId);

		public Property Update(string typeName, string newValue, int attributeId)
		{
			try
			{
				typeName = typeName.ToLower();
				var sql = SqlOptions.GenerateUpdateScript(typeName, newValue, attributeId);
				_context.Database.ExecuteSqlCommand(sql);

				return GetTypeAttributesByName(typeName).FirstOrDefault(a => a.Id == attributeId);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		private readonly InfoSystemDbContext _context;

		private IEnumerable<Property> GetTypeAttributesByName(string typeName)
		{
			ManageQueryType();
			var query = SqlOptions.GenerateSelectScript(typeName);
			return _context.Query<Property>().FromSql(query).ToList();
		}

		private void ManageQueryType()
		{
			if (ModelDoesntHaveAttributeQueryType())
				_context.Model.AsModel().AddQueryType(typeof(Property));
		}

		private bool ModelDoesntHaveAttributeQueryType() => !_context.Model.GetEntityTypes().Any(type =>
			type.IsQueryType && type.Name == "InfoSystem.Core.Entities.Basic.Attribute");
	}
}