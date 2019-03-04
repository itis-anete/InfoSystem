using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class AttributeRepository
	{
		public AttributeRepository(InfoSystemDbContext context)
		{
			_context = context;
		}

		public void Add(Atttribute receivedObj, string typeId)
		{
			var entityType = _context.Types.FirstOrDefault(type => type.Name == typeId);
			if (entityType == null) return;
			receivedObj.TypeId = entityType.Id;
			_context.Atttributes.Add(receivedObj);
			_context.SaveChanges();
		}

		public IEnumerable<Atttribute> Get() => _context.Atttributes;

		private readonly InfoSystemDbContext _context;
	}
}