namespace InfoSystem.Infrastructure.Entities
{
    public class Properties : Identity
    {
        public Properties()
        {
            
        }
        public string Name { get; set; }

        public Entity Entity { get; set; }
    }
}
