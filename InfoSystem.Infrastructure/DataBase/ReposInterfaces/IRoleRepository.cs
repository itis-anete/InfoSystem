using InfoSystem.Core.Entities;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
	public interface IRoleRepository
	{
		Role Create(bool canRead, bool canWrite);
		bool Delete(int roleId);
		Role GetById(int roleId);
		Role Update(Role newRole);
	}
}