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

		public Entity Add(string typeName) => _repository.Add(typeName);

		public bool Delete(int id) => _repository.Delete(id);

		public Entity GetById(int id) => _repository.GetById(id);

		public IEnumerable<Entity> GetByTypeId(int typeId) => _repository.GetByTypeId(typeId);

		public IEnumerable<Entity> GetByTypeName(string typeName) => _repository.GetByTypeName(typeName);

		private readonly IEntityRepository _repository;
	}
}