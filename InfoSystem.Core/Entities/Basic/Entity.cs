using System.ComponentModel.DataAnnotations.Schema;

namespace InfoSystem.Core.Entities.Basic
{
    public class Entity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        [NotMapped] public string Display { get; set; }

        public Entity()
        {
        }

        public Entity(int typeId)
        {
            TypeId = typeId;
        }
    }
}