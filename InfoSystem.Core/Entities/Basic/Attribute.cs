namespace InfoSystem.Core.Entities.Basic
{
	public class Attribute
	{
		public int Id { get; set; }
		public string Key { get; set; }
		public string Value { get; set; }

		public Attribute()
		{
		}

		public Attribute(int id, string key, string value)
		{
			Id = id;
			Key = key;
			Value = value;
		}
	}
}