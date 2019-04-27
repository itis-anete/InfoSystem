using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Repos;

namespace InfoSystem.Sockets.Services
{
	public class PropertyDomainService
	{
		private readonly PropertyRepository _repository;

		public PropertyDomainService(PropertyRepository repository)
		{
			_repository = repository;
		}

		public Property Add(Property newProperty) => _repository.Add(newProperty);

		public bool Delete(int typeId, int attributeId) => _repository.Delete(typeId, attributeId);

		public string GetAttributeValue(string typeName, string attributeName) =>
			_repository.GetAttributeValue(typeName, attributeName);

		public IEnumerable<Property> GetByEntityId(int entityId, int typeId) =>
			_repository.GetByEntityId(entityId, typeId);

		public Property GetByPropertyName(string propertyName, string typeName, int entityId) =>
			_repository.GetByPropertyName(propertyName, typeName, entityId);

		public IEnumerable<Property> GetByTypeName(int entityId, string typeName) =>
			_repository.GetByTypeName(entityId, typeName);

		public IEnumerable<Property> GetTypePropertiesById(int typeId) => _repository.GetTypePropertiesById(typeId);

		public Property Update(int typeId, string newValue, int attributeId) =>
			_repository.Update(typeId, newValue, attributeId);
	}
}