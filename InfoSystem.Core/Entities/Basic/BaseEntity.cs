namespace InfoSystem.Core.Entities
{
    public abstract class BaseEntity : Identity
    {
        public BaseEntity() { }
        public int EntityId { get; set; }
    }
}
