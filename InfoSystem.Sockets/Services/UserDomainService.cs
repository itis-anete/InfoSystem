using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Sockets.Services
{
	public class UserDomainService
	{
		public UserDomainService()
		{
			_repository = new UserRepository(new InfoSystemDbContext());
		}

		public User Get(string login) => _repository.Get(login);

		public User Register(string login, string password) => _repository.Register(login, password);

		public bool Verify(string login, string password) => _repository.VerifyUser(login, password);

		private readonly IUserRepository _repository;
	}
}