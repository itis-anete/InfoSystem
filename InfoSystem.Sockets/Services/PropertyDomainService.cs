using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Sockets.Services
{
	public class PropertyDomainService
	{
		public PropertyDomainService()
		{
			_repository = new PropertyRepository(new InfoSystemDbContext());
		}

		public Property Add(Property newProperty) => _repository.Add(newProperty);

		public bool Delete(string typeName, int attributeId) => _repository.Delete(typeName, attributeId);

		public IEnumerable<Property> GetTypePropertiesById(int typeId) => _repository.GetTypePropertiesById(typeId);

		public IEnumerable<Property> GetByEntityId(int entityId, int typeId) =>
			_repository.GetByEntityId(entityId, typeId);

		public IEnumerable<Property> GetByTypeName(int entityId, string typeName) =>
			_repository.GetByTypeName(entityId, typeName);

		public Property Update(string typeName, string newValue, int attributeId) =>
			_repository.Update(typeName, newValue, attributeId);

		private readonly IPropertyRepository _repository;
	}
}