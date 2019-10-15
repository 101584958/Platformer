using SwinGameSDK;
using Template.Utilities;
using TiledSharp;

namespace Template.Entities
{
    class Player : Actor
    {
        public override int ZIndex => 0;

        public Player(TmxObject tmxObject, TmxMap tmxMap) : base(SwinGame.LoadBitmap(@"Resources\player.png"))
        {
            Position = new Vector2
            {
                X = (float)tmxObject.X,
                Y = (float)tmxObject.Y
            };
        }

        public override void OnUpdate(EntityManager entityManager)
        {
            if (SwinGame.KeyTyped(KeyCode.vk_r))
            {
                Position.Y -= 32;
            }

            if (SwinGame.KeyDown(KeyCode.vk_RIGHT))
            {
                Velocity.X += 12;
            }

            if (SwinGame.KeyDown(KeyCode.vk_LEFT))
            {
                Velocity.X -= 12;
            }

            if (SwinGame.KeyDown(KeyCode.vk_UP) && OnGround)
            {
                Velocity.Y -= 32;
            }

            base.OnUpdate(entityManager);
        }
    }
}
