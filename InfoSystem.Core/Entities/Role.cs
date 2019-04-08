namespace InfoSystem.Core.Entities
{
	public class Role
	{
		public int Id { get; set; }
		public bool CanRead { get; set; }
		public bool CanWrite { get; set; }
		public string Name { get; set; }

		public Role()
		{
		}

		public Role(string name, bool canRead, bool canWrite)
		{
			Name = name;
			CanRead = canRead;
			CanWrite = canWrite;
		}
	}
}