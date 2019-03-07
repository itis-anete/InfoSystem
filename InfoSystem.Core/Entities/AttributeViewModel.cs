using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Core.Entities
{
	public class AttributeViewModel
	{
		public IEnumerable<Attribute> Attributes;
		public string TypeName { get; set; }
	}
}