namespace InfoSystem.Core.Entities.Basic
{
    public class Value 
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int EntityId { get; set; }
        public int AttributeId { get; set; }
        public Attribute Attribute { get; set; }
    }
}
