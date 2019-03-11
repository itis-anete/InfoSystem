using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
	public interface ITypeRepository
	{
		EntityType Add(string typeName);
		IEnumerable<EntityType> Get();
		EntityType GetById(int id);
	    EntityType GetByTypeName(string typeName);
    }
}