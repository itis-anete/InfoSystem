using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Repos;

namespace InfoSystem.Sockets.Services
{
	public class RoleDomainService
	{
		private readonly RoleRepository _repository;

		public RoleDomainService(RoleRepository repository)
		{
			_repository = repository;
		}

		public Role Create(string name, bool canRead, bool canWrite) => _repository.Create(name, canRead, canWrite);

		public bool Delete(int roleId) => _repository.Delete(roleId);

		public Role GetById(int roleId) => _repository.GetById(roleId);

		public Role Update(Role newRole) => _repository.Update(newRole);
	}
}