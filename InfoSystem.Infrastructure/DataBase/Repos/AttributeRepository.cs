using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using Attribute = InfoSystem.Core.Entities.Basic.Attribute;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class AttributeRepository
	{
		public AttributeRepository(InfoSystemDbContext context)
		{
			_context = context;
		}

		public void Add(Attribute receivedObj, string typeName)
		{
			var entityType = _context.Types.FirstOrDefault(type => type.Name == typeName);
			if (entityType == null) return;
			receivedObj.TypeId = entityType.Id;
			_context.Attributes.Add(receivedObj);
			_context.SaveChanges();
		}

		public IEnumerable<Attribute> Get() => _context.Attributes;

		public IEnumerable<Attribute> GetTypeAttributes(string typeName)
		{
			var entityType = _context.Types.FirstOrDefault(t => t.Name == typeName);
			if (entityType == null) return null;
			return _context.Attributes.Where(a => a.TypeId == entityType.Id);
		}

		public Attribute GetByName(string entityType, string attributeName)
		{
			var type = _context.Types.FirstOrDefault(t => t.Name == entityType);
			if (type != null)
				return _context.Attributes.FirstOrDefault(a => a.Name == attributeName && a.TypeId == type.Id);
			Console.WriteLine("go fuck yourself");
			return null;
		}

		private readonly InfoSystemDbContext _context;
	}
}