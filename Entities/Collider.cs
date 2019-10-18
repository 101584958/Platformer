using Template.Utilities;

namespace Template.Entities
{
    class Collider : Entity, ICollidable
    {
        public override int ZIndex => 0;

        public Vector2 Position { get; }
        public Vector2 Size { get; }

        public Collider(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;
        }

        public override void OnUpdate(EntityManager entityManager)
        {
            
        }

        public override void OnRender(EntityManager entityManager)
        {
            
        }
    }
}
