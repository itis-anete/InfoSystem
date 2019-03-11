using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class TypeRepository : ITypeRepository
	{
		public TypeRepository(InfoSystemDbContext dbContext)
		{
			_context = dbContext;
		}

		public EntityType Add(string typeName)
		{
			try
			{
				var entityEntry = _context.Types.Add(new EntityType(typeName));
				_context.SaveChanges();
				return entityEntry.Entity;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		public IEnumerable<EntityType> Get()
		{
			return _context.Types;
		}

		public EntityType GetById(int id)
		{
			return _context.Types.Find(id);
		}

	    public EntityType GetByTypeName(string typeName)
	    {
	        return _context.Types.FirstOrDefault(x => x.Name == typeName);
	    }

        private readonly InfoSystemDbContext _context;
	}
}