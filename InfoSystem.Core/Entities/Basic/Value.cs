namespace InfoSystem.Core.Entities.Basic
{
    public class Value
    {
        public Value()
        {
        }

        public Value(string content, int entityId, int attributeId)
        {
            Content = content;
            EntityId = entityId;
            AttributeId = attributeId;
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int EntityId { get; set; }
        public int AttributeId { get; set; }
        public Attribute Attribute { get; set; }
    }
}