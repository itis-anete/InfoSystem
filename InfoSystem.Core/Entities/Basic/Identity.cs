using System.ComponentModel.DataAnnotations;

namespace InfoSystem.Core.Entities
{
    public abstract class Identity
    {
        [Key]
        public int Id { get; set; }
    }
}
