using SwinGameSDK;
using System.Collections.Generic;
using Template.Utilities;
using TiledSharp;

namespace Template.Entities
{
    public class Player : Actor
    {
        private int _keyCount = 0;
        private int _totalKeyCount = -1;

        public override int ZIndex => 1;

        private readonly int _mapWidth, _mapHeight;

        private Bitmap _flippedBitmap;
        private bool _flipped = false;

        public Player(TmxObject tmxObject, TmxMap tmxMap) : base(SwinGame.LoadBitmap(@"Resources\player.png"))
        {
            Position = new Vector2
            {
                X = (float)tmxObject.X,
                Y = (float)tmxObject.Y
            };

            _mapWidth = tmxMap.Width * tmxMap.TileWidth;
            _mapHeight = tmxMap.Height * tmxMap.TileHeight;

            _flippedBitmap = SwinGame.LoadBitmap(@"Resources\player-flipped.png");
        }

        public override void OnUpdate(EntityManager entityManager)
        {
            if (SwinGame.KeyDown(KeyCode.vk_RIGHT))
            {
                Velocity.X += 32;
                _flipped = false;
            }

            if (SwinGame.KeyDown(KeyCode.vk_LEFT))
            {
                Velocity.X -= 32;
                _flipped = true;
            }

            if (SwinGame.KeyDown(KeyCode.vk_UP) && OnGround)
            {
                Velocity.Y -= 48;
            }

            base.OnUpdate(entityManager);

            if (Position.X < 0) Position.X = 0;
            if (Position.Y < 0) Position.Y = 0;
            if (Position.X + Size.X > _mapWidth) Position.X = _mapWidth - Size.X;
            if (Position.Y + Size.Y > _mapHeight) Position.Y = _mapHeight - Size.Y;

            List<Key> keys = entityManager.GetEntitiesByType<Key>();

            foreach (Key key in keys)
            {
                if (Collision.CheckCollision(this, key) != null)
                {
                    _keyCount++;
                    entityManager.RemoveEntity(key);
                }
            }

            if (_totalKeyCount == -1) _totalKeyCount = keys.Count;
        }

        public override void OnRender(EntityManager entityManager)
        {
            SwinGame.DrawBitmap(_flipped ? _flippedBitmap : Bitmap, Position);

            string keyText = $"{_keyCount} / {_totalKeyCount} ({(_keyCount / (float)_totalKeyCount * 100.0f):N0}%) keys collected";

            int textWidth = SwinGame.TextWidth(FontUtilities.Arial24, keyText);
            int textHeight = SwinGame.TextHeight(FontUtilities.Arial24, keyText);

            SwinGame.FillRectangle(SwinGame.RGBAFloatColor(0.0f, 0.0f, 0.0f, 0.5f), SwinGame.CameraX(), SwinGame.CameraY(), textWidth + 4, textHeight + 4);
            FontUtilities.DrawString(FontUtilities.Arial24, keyText, 2.0f + SwinGame.CameraX(), 2.0f + SwinGame.CameraY(), Color.White);

            SwinGame.SetCameraPos(new Point2D
            {
                X = MathUtilities.Clamp(Position.X + Size.X - SwinGame.ScreenWidth() / 2.0f, 0.0f, _mapWidth - SwinGame.ScreenWidth()),
                Y = MathUtilities.Clamp(Position.Y + Size.Y - SwinGame.ScreenHeight() / 2.0f, 0.0f, _mapHeight - SwinGame.ScreenHeight())
            });
        }

        public override void OnCheckCollision(List<Collider> colliders)
        {
            foreach (Collider collider in colliders)
            {
                Vector2 penetrationVector = Collision.CheckCollision(this, collider);

                if (collider.TileGid == 38 || collider.TileGid == 39 || collider.TileGid == 40)
                {
                    if (SwinGame.KeyDown(KeyCode.vk_DOWN) || Velocity.Y < 0) continue;
                }

                if (penetrationVector != null)
                {
                    Position -= penetrationVector;

                    if (!MathUtilities.ApproximatelyEqual(penetrationVector.X, 0)) Velocity.X = 0;

                    if (!MathUtilities.ApproximatelyEqual(penetrationVector.Y, 0))
                    {
                        Velocity.Y = 0;
                        if (penetrationVector.Y > 0) OnGround = true;
                    }
                }
            }
        }
    }
}
