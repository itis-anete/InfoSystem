using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
	public interface ITypeRepository
	{
		bool Add(string typeName, out EntityType outType);
		IEnumerable<EntityType> Get();
		EntityType GetById(int id);
	    EntityType GetByTypeName(string typeName);
    }
}