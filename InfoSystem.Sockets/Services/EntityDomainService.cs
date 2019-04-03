using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Sockets.Services
{
	public class EntityDomainService
	{
		public EntityDomainService(IEntityRepository repository)
		{
			_repository = repository;
		}

		public Entity Add(string typeName, string requiredAttributeValue) => 	_repository.Add(typeName, requiredAttributeValue);

		public bool Delete(int id) => _repository.Delete(id);

		public Entity GetById(int id) => _repository.GetById(id);

		public IEnumerable<Entity> GetByTypeId(int typeId) => _repository.GetByTypeId(typeId);

		public IEnumerable<Entity> GetByTypeName(string typeName) => _repository.GetByTypeName(typeName);

		private readonly IEntityRepository _repository;
	}
}