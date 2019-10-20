using SwinGameSDK;
using System.Collections.Generic;
using Template.Utilities;
using TiledSharp;

namespace Template.Entities
{
    class Player : Actor
    {
        private int _keyCount = 0;
        private int _totalKeyCount = -1;

        public override int ZIndex => 1;

        private readonly int _mapWidth, _mapHeight;

        public Player(TmxObject tmxObject, TmxMap tmxMap) : base(SwinGame.LoadBitmap(@"Resources\player.png"))
        {
            Position = new Vector2
            {
                X = (float)tmxObject.X,
                Y = (float)tmxObject.Y
            };

            _mapWidth = tmxMap.Width * tmxMap.TileWidth;
            _mapHeight = tmxMap.Height * tmxMap.TileHeight;
        }

        public override void OnUpdate(EntityManager entityManager)
        {
            if (SwinGame.KeyDown(KeyCode.vk_RIGHT))
            {
                Velocity.X += 32;
            }

            if (SwinGame.KeyDown(KeyCode.vk_LEFT))
            {
                Velocity.X -= 32;
            }

            if (SwinGame.KeyDown(KeyCode.vk_UP) && OnGround)
            {
                Velocity.Y -= 48;
            }

            base.OnUpdate(entityManager);

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
            base.OnRender(entityManager);

            string keyText = $"{_keyCount} / {_totalKeyCount} ({(_keyCount / (float)_totalKeyCount * 100.0f):N0}%) keys collected";

            int textWidth = SwinGame.TextWidth(FontUtilities.Arial24, keyText);
            int textHeight = SwinGame.TextHeight(FontUtilities.Arial24, keyText);

            SwinGame.FillRectangle(SwinGame.RGBAFloatColor(0.0f, 0.0f, 0.0f, 0.5f), SwinGame.CameraX(), SwinGame.CameraY(), textWidth + 4, textHeight + 4);
            FontUtilities.DrawString(FontUtilities.Arial24, keyText, 2.0f + SwinGame.CameraX(), 2.0f + SwinGame.CameraY(), Color.White);

            SwinGame.SetCameraPos(new Point2D
            {
                X = MathUtilities.Clamp(Position.X + Size.X - SwinGame.ScreenWidth() / 2.0f, 0.0f, _mapWidth),
                Y = MathUtilities.Clamp(Position.Y + Size.Y - SwinGame.ScreenHeight() / 2.0f, 0.0f, _mapHeight)
            });
        }
    }
}
