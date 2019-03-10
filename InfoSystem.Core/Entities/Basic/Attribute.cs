namespace InfoSystem.Core.Entities.Basic
{
	public class Attribute
	{
		public Attribute()
		{
		}

		public Attribute(string name, int typeId, ValueType valueType)
		{
			Name = name;
			TypeId = typeId;
			ValueType = valueType;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public int TypeId { get; set; }
		public ValueType ValueType { get; set; }
	}
}