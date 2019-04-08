using System.ComponentModel.DataAnnotations.Schema;

namespace InfoSystem.Core.Entities.Basic
{
    public class Property
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int TypeId { get; set; }
        public int EntityId { get; set; }
        public bool IsComplex => Key.StartsWith("Complex:");
        [NotMapped] public string DisplayComplexValue { get; set; }

        public Property()
        {
        }

        public Property(string key, string value, int typeId, int entityId)
        {
            Key = key;
            Value = value;
            TypeId = typeId;
            EntityId = entityId;
        }
    }
}