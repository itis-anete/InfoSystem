namespace InfoSystem.Core.Entities.Basic
{
	public class Property
	{
		public int Id { get; set; }
		public string Key { get; set; }
		public string Value { get; set; }
		public int TypeId { get; set; }
		public int EntityId { get; set; }

		public bool IsComplex => Key.StartsWith("Complex:");
	}
}