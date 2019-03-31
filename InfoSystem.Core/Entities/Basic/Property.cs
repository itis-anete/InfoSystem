namespace InfoSystem.Core.Entities.Basic
{
    public class Property
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int TypeId { get; set; }
        public int EntityId { get; set; }

        public Property(string key, string value, int typeId, int entityId)
        {
            Key = key;
            Value = value;
            TypeId = typeId;
            EntityId = entityId;
        }

        public Property()
        {
            
        }

        public bool IsComplex => Key.StartsWith("Complex:");
    }
}