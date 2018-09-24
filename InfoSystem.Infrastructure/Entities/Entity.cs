using System.Collections.Generic;

namespace InfoSystem.Infrastructure.Entities
{
    public class Entity : BaseEntity
    {
        public Entity() { }
        public bool Editable { get; set; }
        
        public ICollection<Properties> Properties { get; set; }
    }
}
