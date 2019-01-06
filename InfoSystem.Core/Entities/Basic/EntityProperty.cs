using System;

namespace InfoSystem.Core.Entities
{
	public class EntityProperty : Identity
	{
		public int EntityId { get; set; }
		public int PropertyId { get; set; }
	}
}