namespace InfoSystem.Core.Entities.Basic
{
	public class Attribute
	{
		public int Id { get; set; }
		public int Key { get; set; }
		public string Value { get; set; }
		public int TypeId { get; set; }
		public ValueType EntityId { get; set; }
	}
}