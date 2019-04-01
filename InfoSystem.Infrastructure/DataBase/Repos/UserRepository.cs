using System;
using System.Linq;
using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class UserRepository : IUserRepository
	{
		public UserRepository(InfoSystemDbContext context)
		{
			_context = context;
		}

		public User Get(string login) => _context.Users.FirstOrDefault(u => u.Login == login);

		public User Register(string login, string password, Role role = null)
		{
			try
			{
				var entityEntry = _context.Users.Add(new User(login, password, role));
				_context.SaveChanges();
				return entityEntry.Entity;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		public bool VerifyUser(string login, string password)
		{
			var user = _context.Users.FirstOrDefault(u => u.Login == login);
			return user != null && user.Password == password;
		}

		private readonly InfoSystemDbContext _context;
	}
}