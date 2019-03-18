using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Sockets.Services
{
	public class EntityDomainService
	{
		public EntityDomainService()
		{
			_repository = new EntityRepository(new InfoSystemDbContext());
		}

		public Entity Add(string typeName)
		{
			return _repository.Add(typeName);
		}

		public bool Delete(int id)
		{
			return _repository.Delete(id);
		}

		public Entity GetById(int id)
		{
			return _repository.GetById(id);
		}

		public IEnumerable<Entity> GetByTypeId(int typeId)
		{
			return _repository.GetByTypeId(typeId);
		}

		public IEnumerable<Entity> GetByTypeName(string typeName)
		{
			return _repository.GetByTypeName(typeName);
		}

		private readonly IEntityRepository _repository;
	}
}