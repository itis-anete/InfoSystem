using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
	public interface IAttributeRepository
	{
		bool Add(string typeName, string attributeName, string value, int typeId, int entityId);
		IEnumerable<Attribute> Get(string typeName);
		Attribute GetById(int id);
		Attribute GetById(int entityTypeId, int attributeId);
		Attribute GetByName(int entityTypeId, string attributeName);
		IEnumerable<Attribute> GetTypeAttributes(string typeName);
		IEnumerable<Attribute> GetTypeAttributesById(int typeId);
		IEnumerable<Attribute> GetByEntityId(int entityId, string typeName);
	}
}