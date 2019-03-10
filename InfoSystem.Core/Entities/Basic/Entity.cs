namespace InfoSystem.Core.Entities.Basic
{
    public class Entity
    {
        public Entity()
        {
        }

        public Entity(int typeId)
        {
            TypeId = typeId;
        }

        public int Id { get; set; }
        public int TypeId { get; set; }
    }
}