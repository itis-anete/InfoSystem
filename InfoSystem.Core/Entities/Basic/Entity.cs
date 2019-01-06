using System.Collections.Generic;
using System.Linq;

namespace InfoSystem.Core.Entities
{
    public class Entity : BaseEntity
    {
        public Entity()
        {
        }

        public bool Editable { get; set; }

        public IEnumerable<Properties> Properties { get; set; }

        public override string ToString()
        {
            return EntityId.ToString() + Editable;
        }
    }
}