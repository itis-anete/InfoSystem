using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
	public interface IEntityRepository
	{
		Entity Add(string typeName);
		bool Delete(int id);
		Entity GetById(int id);
		IEnumerable<Entity> GetByTypeId(int typeId);
		IEnumerable<Entity> GetByTypeName(string typeName);
	}
}