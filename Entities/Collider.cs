using Template.Utilities;

namespace Template.Entities
{
    public class Collider : Entity, ICollidable
    {
        public override int ZIndex => 0;

        public int TileGid { get; }

        public Vector2 Position { get; }
        public Vector2 Size { get; }

        public Collider(int tileGid, Vector2 position, Vector2 size)
        {
            TileGid = tileGid;
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
