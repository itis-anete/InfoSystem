namespace InfoSystem.Core.Entities.Basic
{
	public class Attribute
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int TypeId { get; set; }
		public ValueType ValueType { get; set; }
	}
}