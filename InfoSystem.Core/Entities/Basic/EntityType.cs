namespace InfoSystem.Core.Entities.Basic
{
	public class EntityType
	{
		public EntityType()
		{
		}

		public EntityType(string name)
		{
			Name = name;
		}

		public int Id { get; set; }
		public string Name { get; set; }
	}
}