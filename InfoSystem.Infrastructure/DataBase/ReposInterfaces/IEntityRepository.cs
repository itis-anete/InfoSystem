using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
	public interface IEntityRepository
	{
		void Add(string typeName);
		void Delete(int id);
		IEnumerable<Entity> Get();
		Entity GetById(int id);
		IEnumerable<Entity> GetByTypeId(int typeId);
	}
}