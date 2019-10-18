using SwinGameSDK;
using Template.Utilities;
using TiledSharp;

namespace Template.Entities
{
    class Key : Actor, ICollidable
    {
        public override int ZIndex => 0;

        public Key(TmxObject tmxObject, TmxMap tmxMap) : base(SwinGame.LoadBitmap(@"Resources\key.png"))
        {
            Position = new Vector2
            {
                X = (float)tmxObject.X,
                Y = (float)tmxObject.Y + 4
            };
        }

        public override void OnUpdate(EntityManager entityManager)
        {
            base.OnUpdate(entityManager);
        }

        public override void OnRender(EntityManager entityManager)
        {
            base.OnRender(entityManager);
        }
    }
}
