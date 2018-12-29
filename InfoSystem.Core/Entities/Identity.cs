using System.ComponentModel.DataAnnotations;

namespace InfoSystem.Infrastructure.Entities
{
    public abstract class Identity
    {
        [Key]
        public int Id { get; set; }
    }
}
