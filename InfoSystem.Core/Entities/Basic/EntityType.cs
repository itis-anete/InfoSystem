namespace InfoSystem.Core.Entities.Basic
{
	public class EntityType
	{
		public EntityType()
		{
		}

		public EntityType(string name, string requiredProperty)
		{
			Name = name;
		    RequiredProperty = requiredProperty;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string RequiredProperty { get; set; }
	}
}