using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class TypeRepository : IBaseRepository<EntityType>
	{
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
			throw new System.NotImplementedException();
		}

		public EntityType GetById(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}