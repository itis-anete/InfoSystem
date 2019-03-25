using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Sockets.Services
{
	public class RoleDomainService
	{
		public RoleDomainService()
		{
			_repository = new RoleRepository(new InfoSystemDbContext());
		}

		public Role Create(bool canRead, bool canWrite) => _repository.Create(canRead, canWrite);

		public bool Delete(int roleId) => _repository.Delete(roleId);

		public Role GetById(int roleId) => _repository.GetById(roleId);

		public Role Update(Role newRole) => _repository.Update(newRole);

		private readonly IRoleRepository _repository;
	}
}