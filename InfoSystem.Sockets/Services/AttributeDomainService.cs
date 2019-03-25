using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Sockets.Services
{
	public class AttributeDomainService
	{
		public AttributeDomainService()
		{
			_repository = new AttributeRepository(new InfoSystemDbContext());
		}

		public Attribute Add(Attribute newAttribute) => _repository.Add(newAttribute);

		public bool Delete(string typeName, int attributeId) => _repository.Delete(typeName, attributeId);

		public IEnumerable<Attribute> GetTypeAttributesById(int typeId) => _repository.GetTypeAttributesById(typeId);

		public IEnumerable<Attribute> GetByEntityId(int entityId, int typeId) => 
			_repository.GetByEntityId(entityId, typeId);

		public IEnumerable<Attribute> GetByTypeName(int entityId, string typeName) => 
			_repository.GetByTypeName(entityId, typeName);

		public Attribute Update(string typeName, string newValue, int attributeId) => 
			_repository.Update(typeName, newValue, attributeId);

		private readonly IAttributeRepository _repository;
	}
}