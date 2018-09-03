using System.ComponentModel.DataAnnotations;

namespace InfoSystem.App.DataBase.Entities
{
    public abstract class Identity
    {
        [Key]
        public int Id { get; set; }
    }
}
