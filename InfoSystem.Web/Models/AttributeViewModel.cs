using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Web.Models
{
	public class AttributeViewModel
	{
		public IEnumerable<Attribute> Attributes;
		public string TypeName { get; set; }
	}
}