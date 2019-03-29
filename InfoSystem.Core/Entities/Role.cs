namespace InfoSystem.Core.Entities
{
	public class Role
	{
		public Role()
		{
		}

		public Role(bool canRead, bool canWrite)
		{
			CanRead = canRead;
			CanWrite = canWrite;
		}

		public int Id { get; set; }
		public bool CanRead { get; set; }
		public bool CanWrite { get; set; }
		public string Name { get; set; }
	}
}