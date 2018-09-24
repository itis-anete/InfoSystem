namespace InfoSystem.Infrastructure.Entities
{
    public abstract class BaseEntity : Identity
    {
        public string EntityId { get; set; }
    }
}
