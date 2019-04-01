using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
	public interface IPropertyRepository
	{
		Property Add(Property newProperty);
		bool Delete(string typeName, int attributeId);
		string GetAttributeValue(string typeName, string attributeName);
		IEnumerable<Property> GetByEntityId(int entityId, int typeId);
		Property GetByPropertyName(string propertyName, string typeName, int entityId);
		IEnumerable<Property> GetByTypeName(int entityId, string typeName);
		IEnumerable<Property> GetTypePropertiesById(int typeId);
		Property Update(string typeName, string newValue, int attributeId);
	}
}