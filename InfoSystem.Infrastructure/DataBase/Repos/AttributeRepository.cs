using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Attribute = InfoSystem.Core.Entities.Basic.Attribute;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class AttributeRepository : IAttributeRepository
	{
		public AttributeRepository(InfoSystemDbContext context)
		{
			_context = context;
		}

		public Attribute Add(Attribute newAttribute)
		{
			try
			{
				var typeName = _context.Types.Find(newAttribute.TypeId)?.Name;
				var sql = SqlOptions.GenerateInsertIntoScript(typeName, newAttribute);
				_context.Database.ExecuteSqlCommand(sql);
				if (ModelDoesntHaveAttributeQueryType())
					_context.Model.AsModel().AddQueryType(typeof(Attribute));

				var query = SqlOptions.GenerateSelectScript(typeName);
				return _context.Query<Attribute>().FromSql(query).ToList().FirstOrDefault(a => a.Key == newAttribute.Key);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		public IEnumerable<Attribute> GetTypeAttributesById(int typeId)
		{
			var typeName = _context.Types.Find(typeId)?.Name;
			return GetTypeAttributesByName(typeName);
		}

		public IEnumerable<Attribute> GetByEntityId(int entityId, int typeId) => 
			GetTypeAttributesById(typeId).Where(a => a.EntityId == entityId);

		public IEnumerable<Attribute> GetTypeAttributesByName(string typeName)
		{
			if (ModelDoesntHaveAttributeQueryType())
				_context.Model.AsModel().AddQueryType(typeof(Attribute));

			var query = SqlOptions.GenerateSelectScript(typeName);
			return _context.Query<Attribute>().FromSql(query).ToList();
		}

		public IEnumerable<Attribute> GetByTypeName(int entityId, string typeName) => 
			GetTypeAttributesByName(typeName).Where(a => a.EntityId == entityId);

		private readonly InfoSystemDbContext _context;

		private bool ModelDoesntHaveAttributeQueryType() => !_context.Model.GetEntityTypes().Any(type =>
			type.IsQueryType && type.Name == "InfoSystem.Core.Entities.Basic.Attribute");
	}
}