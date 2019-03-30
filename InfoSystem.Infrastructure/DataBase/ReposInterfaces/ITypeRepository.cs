using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
	public interface ITypeRepository
	{
		EntityType Add(string typeName, string requiredProperty);
		IEnumerable<EntityType> Get();
		EntityType GetById(int id);
    }
}