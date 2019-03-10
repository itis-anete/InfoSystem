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

		public bool Add(string typeName)
		{
			try
			{
				var newType = new EntityType(typeName);
				_context.Types.Add(newType);
				_context.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return false;
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