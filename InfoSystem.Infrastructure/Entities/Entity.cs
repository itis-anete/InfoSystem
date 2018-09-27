using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoSystem.Infrastructure.Entities
{
    [Table("Entities")]
    public class Entity : BaseEntity
    {
        public Entity() { }
        
        public bool Editable { get; set; }
        
        public IEnumerable<Properties> Properties { get; set; }
    }
}