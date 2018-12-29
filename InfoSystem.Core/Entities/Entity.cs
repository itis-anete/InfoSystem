using System.Collections.Generic;

namespace InfoSystem.Core.Entities
{
    public class Entity : BaseEntity
    {
        public Entity() { }
        
        public bool Editable { get; set; }
        
        public IEnumerable<Properties> Properties { get; set; }
    }
}