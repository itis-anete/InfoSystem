using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class TypeRepository : IBaseRepository<EntityType>
	{
	    public TypeRepository(InfoSystemDbContext dbContext)
	    {
	        _context = dbContext;
        }

		public void Add(EntityType receivedObj)
		{
			throw new System.NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<EntityType> Get()
		{
		    return _context.Types;
		}

		public EntityType GetById(int id)
		{
			throw new System.NotImplementedException();
		}

	    private readonly InfoSystemDbContext _context;
    }
}