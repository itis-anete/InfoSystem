using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
	public interface IAttributeRepository
	{
		Attribute Add(Attribute newAttribute);
		bool Delete(string typeName, int attributeId);
		IEnumerable<Attribute> GetTypeAttributesById(int typeId);
		IEnumerable<Attribute> GetByEntityId(int entityId, int typeId);
	    IEnumerable<Attribute> GetByTypeName(int entityId, string typeName);
	    Attribute Update(string typeName, string newValue, int attributeId);
	}
}