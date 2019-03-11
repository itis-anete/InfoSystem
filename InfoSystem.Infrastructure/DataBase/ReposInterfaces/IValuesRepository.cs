using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
	public interface IValuesRepository
	{
		Value Add(Value receivedObj);
		Value GetById(int entityId, string attributeName);
		Value GetById(int id);
		IEnumerable<Value> GetEntityValues(int entityId);
		Value Update(Value updatedValue);
	}
}