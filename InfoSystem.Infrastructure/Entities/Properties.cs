namespace InfoSystem.Infrastructure.Entities
{
    public class Properties : Identity
    {
        public string Name { get; set; }

        public Entity Entity { get; set; }
    }
}
