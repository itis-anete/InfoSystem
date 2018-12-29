namespace InfoSystem.Core.Entities
{
    public class Properties : Identity
    {
        public Properties()
        {
        }

        public string Name { get; set; }
        
        public Entity Entity { get; set; }
        public Values Value { get; set; }
    }
}