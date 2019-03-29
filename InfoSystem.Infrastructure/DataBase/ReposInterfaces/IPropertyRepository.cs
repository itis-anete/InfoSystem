using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
	public interface IPropertyRepository
	{
		Property Add(Property newProperty);
		bool Delete(string typeName, int attributeId);
		IEnumerable<Property> GetTypePropertiesById(int typeId);
		IEnumerable<Property> GetByEntityId(int entityId, int typeId);
	    IEnumerable<Property> GetByTypeName(int entityId, string typeName);
	    Property Update(string typeName, string newValue, int attributeId);
	}
}