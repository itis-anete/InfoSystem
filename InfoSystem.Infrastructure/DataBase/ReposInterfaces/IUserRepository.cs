using InfoSystem.Core.Entities;

namespace InfoSystem.Infrastructure.DataBase.ReposInterfaces
{
	public interface IUserRepository
	{
		User Get(string login);
		User Register(string login, string password);
		bool VerifyUser(string login, string password);
	}
}