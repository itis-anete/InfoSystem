using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
	public interface IAttributeRepository
	{
		bool Add(string typeName, string attributeName, string value, int typeId, int entityId);
		IEnumerable<Attribute> GetTypeAttributesById(int typeId);
		IEnumerable<Attribute> GetByEntityId(int entityId, int typeId);
	    IEnumerable<Attribute> GetByTypeName(int entityId, string typeName);
    }
}