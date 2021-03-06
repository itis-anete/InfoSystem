namespace InfoSystem.Core.Entities
{
	public class User
	{
		public string Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public Role Role { get; set; }

		public User()
		{
		}

		public User(string login, string password, Role role)
		{
			Login = login;
			Password = password;
			Role = role;
		}
	}
}