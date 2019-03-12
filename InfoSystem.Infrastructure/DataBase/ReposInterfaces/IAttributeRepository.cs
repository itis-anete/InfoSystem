using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
	public interface IAttributeRepository
	{
		Attribute Add(string attributeName, string valueType, string typeName);
		IEnumerable<Attribute> Get(string typeName);
		Attribute GetById(int id);
		Attribute GetById(int entityTypeId, int attributeId);
		Attribute GetByName(int entityTypeId, string attributeName);
		IEnumerable<Attribute> GetTypeAttributes(string typeName);
		IEnumerable<Attribute> GetTypeAttributesById(int typeId);
	}
}