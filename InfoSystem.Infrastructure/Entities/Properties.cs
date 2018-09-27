using System.ComponentModel.DataAnnotations.Schema;

namespace InfoSystem.Infrastructure.Entities
{
    [Table("Properties")]
    public class Properties : Identity
    {
        public Properties()
        {
        }

        public string Name { get; set; }
        
        //[ForeignKey("Entity")]
        public Entity Entity { get; set; }
        public Values Value { get; set; }
    }
}