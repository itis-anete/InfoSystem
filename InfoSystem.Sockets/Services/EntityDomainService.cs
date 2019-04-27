using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Repos;

namespace InfoSystem.Sockets.Services
{
	public class EntityDomainService
	{
		private readonly EntityRepository _repository;

		public EntityDomainService(EntityRepository repository)
		{
			_repository = repository;
		}

		public Entity Add(int typeId, string requiredAttributeValue) =>
			_repository.Add(typeId, requiredAttributeValue);

		public bool Delete(int id) => _repository.Delete(id);

		public Entity GetById(int id) => _repository.GetById(id);
		
		public IEnumerable<Entity> GetByTypeId(int typeId) => _repository.GetByTypeId(typeId);

		public IEnumerable<Entity> GetByTypeName(string typeName) => _repository.GetByTypeName(typeName);

		public IEnumerable<Dictionary<string, string>> GetMenu() => _repository.GetMenu();
	}
}