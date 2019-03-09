using System;
using System.Collections.Generic;
using System.Linq;
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

		public void Add(string attributeName, string valueType, string typeName)
		{
			var entityType = _context.Types.FirstOrDefault(type => type.Name == typeName);
			if (entityType == null) return;
			var attribute = new Attribute
			{
				TypeId = entityType.Id,
				Name = attributeName,
				ValueType = valueType
			};
			_context.Attributes.Add(attribute);
			_context.SaveChanges();
		}

		[Obsolete]
		public IEnumerable<Attribute> Get() => _context.Attributes;

		public Attribute GetById(int id)
		{
			return _context.Attributes.FirstOrDefault(a => a.Id == id);
		}

		public IEnumerable<Attribute> GetTypeAttributes(string typeName)
		{
			var entityType = _context.Types.FirstOrDefault(t => t.Name == typeName);
			return entityType == null
				? null
				: _context.Attributes.Where(a => a.TypeId == entityType.Id);
		}

		public Attribute GetById(int entityTypeId, int attributeId)
		{
			bool Func(Attribute a, int attributeName) => a.Id == attributeId;
			return Get(entityTypeId, attributeId, Func);
		}

		public IEnumerable<Attribute> GetTypeAttributesById(int typeId)
		{
			return _context.Attributes.Where(a => a.TypeId == typeId);
		}

		public Attribute GetByName(int entityTypeId, string attributeName)
		{
			bool Func(Attribute a, string name) => a.Name == name;
			return Get(entityTypeId, attributeName, Func);
		}

		private Attribute Get<T>(int entityTypeId, T searchParameter, Func<Attribute, T, bool> selector)
		{
			var type = _context.Types.FirstOrDefault(t => t.Id == entityTypeId);
			return type != null
				? _context.Attributes.FirstOrDefault(a => selector(a, searchParameter) && a.TypeId == type.Id)
				: null;
		}

		private readonly InfoSystemDbContext _context;
	}
}