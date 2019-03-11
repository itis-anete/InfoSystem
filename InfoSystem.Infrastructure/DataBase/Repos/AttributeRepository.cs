using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using Attribute = InfoSystem.Core.Entities.Basic.Attribute;
using ValueType = InfoSystem.Core.Entities.ValueType;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class AttributeRepository : IAttributeRepository
	{
		public AttributeRepository(InfoSystemDbContext context)
		{
			_context = context;
		}

		public Attribute Add(string attributeName, string valueType, string typeName)
		{
			EntityType entityType;
			try
			{
				entityType = _context.Types.FirstOrDefault(type => type.Name == typeName);
				if (entityType == null)
					return null;
			}
			catch (Exception e)
			{
				Console.WriteLine("TYPES FAILED");
				Console.WriteLine(e);
				return null;
			}

			try
			{
				var attribute = new Attribute(attributeName, entityType.Id, Enum.Parse<ValueType>(valueType));
				var entityEntry = _context.Attributes.Add(attribute);
				_context.SaveChanges();
				return entityEntry.Entity;
			}
			catch (Exception e)
			{
				Console.WriteLine("ATTRIBUTE FAIL");
				Console.WriteLine(e);
				return null;
			}
		}

		public IEnumerable<Attribute> Get() => _context.Attributes;

		public Attribute GetById(int id)
		{
			return _context.Attributes.FirstOrDefault(a => a.Id == id);
		}

		public Attribute GetById(int entityTypeId, int attributeId)
		{
			bool Func(Attribute a, int attributeName) => a.Id == attributeId;
			return Get(entityTypeId, attributeId, Func);
		}

		public Attribute GetByName(int entityTypeId, string attributeName)
		{
			bool Func(Attribute a, string name) => a.Name == name;
			return Get(entityTypeId, attributeName, Func);
		}

		public IEnumerable<Attribute> GetTypeAttributes(string typeName)
		{
			var entityType = _context.Types.FirstOrDefault(t => t.Name == typeName);
			return entityType == null
				? null
				: _context.Attributes.Where(a => a.TypeId == entityType.Id);
		}

		public IEnumerable<Attribute> GetTypeAttributesById(int typeId)
		{
			return _context.Attributes.Where(a => a.TypeId == typeId);
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