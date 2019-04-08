using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Sockets.Services
{
	public class TypeDomainService
	{
		private readonly ITypeRepository _repository;

		public TypeDomainService(ITypeRepository repository)
		{
			_repository = repository;
		}

		public EntityType Add(string typeName, string requiredProperty) => _repository.Add(typeName, requiredProperty);

		public IEnumerable<EntityType> Get() => _repository.Get();

		public EntityType GetById(int id) => _repository.GetById(id);
	}
}