using SwinGameSDK;
using Template.Scenes;
using Template.Utilities;
using TiledSharp;

namespace Template.Entities
{
    class Flag : Actor
    {
        public Flag(TmxObject tmxObject, TmxMap tmxMap) : base(SwinGame.LoadBitmap(@"Resources\flag.png"))
        {
            Position = new Vector2
            {
                X = (float)tmxObject.X,
                Y = (float)tmxObject.Y
            };
        }

        public override void OnUpdate(EntityManager entityManager)
        {
            base.OnUpdate(entityManager);

            if (Collision.CheckCollision(this, entityManager.GetEntitiesByType<Player>()[0]) != null)
            {
                Program.SceneManager.SetScene(new WinScene());
            }
        }
    }
}
