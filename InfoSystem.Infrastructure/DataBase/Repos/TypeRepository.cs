using System;
using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class TypeRepository
	{
		public TypeRepository(InfoSystemDbContext dbContext)
		{
			_context = dbContext;
		}

		public bool Add(string typeName)
		{
			try
			{
				var newType = new EntityType() {Name = typeName};
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
		
		public EntityType GetById(int id)
		{
			return _context.Types.Find(id);
		}

	    public IEnumerable<EntityType> Get()
	    {
	        return _context.Types;
	    }


        private readonly InfoSystemDbContext _context;
	}
}