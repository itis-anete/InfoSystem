using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Sockets.Services
{
	public class TypeDomainService
	{
		public TypeDomainService()
		{
			_repository = new TypeRepository(new InfoSystemDbContext());
		}

		public EntityType Add(string typeName)
		{
			return _repository.Add(typeName);
		}

		public IEnumerable<EntityType> Get()
		{
			return _repository.Get();
		}

		public EntityType GetById(int id)
		{
			return _repository.GetById(id);
		}

		private readonly ITypeRepository _repository;
	}
}