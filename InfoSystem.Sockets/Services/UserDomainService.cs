using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Repos;

namespace InfoSystem.Sockets.Services
{
	public class UserDomainService
	{
		private readonly UserRepository _repository;

		public UserDomainService(UserRepository repository)
		{
			_repository = repository;
		}

		public User Get(string login) => _repository.Get(login);

		public User Register(string login, string password) => _repository.Register(login, password);

		public bool Verify(string login, string password) => _repository.VerifyUser(login, password);
	}
}