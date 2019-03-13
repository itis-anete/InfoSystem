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

		public bool Add(string typeName, string attributeName, string value, int typeId, int entityId)
		{
			try
			{
				var sql =
					$"INSERT INTO {typeName} (key,value,typeid,entityid) VALUES ('{attributeName}','{value}',{typeId},{entityId});";
				_context.Database.ExecuteSqlCommand(sql);
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return false;
			}
		}

		public IEnumerable<Attribute> GetTypeAttributesById(int typeId)
		{
			var typeName = _context.Types.Find(typeId)?.Id;
			if (!_context.Model.GetEntityTypes().Any(type =>
				type.IsQueryType && type.Name == "InfoSystem.Core.Entities.Basic.Attribute"))
				_context.Model.AsModel().AddQueryType(typeof(Attribute));

			var query = $"SELECT * FROM \"{typeName}\"";
			return _context.Query<Attribute>().FromSql(query).ToList();
		}

		public IEnumerable<Attribute> GetByEntityId(int entityId, int typeId)
		{
			return GetTypeAttributesById(typeId).Where(a => a.EntityId == entityId);
		}

		private readonly InfoSystemDbContext _context;
	}
}