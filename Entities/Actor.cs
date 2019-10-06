using System;
using SwinGameSDK;
using Template.Utilities;

namespace Template.Entities
{
    public class Actor : Entity
    {
        private const float Gravity = 1.0f, GravityLimit = 12.0f;
        private const float Friction = 1.0f, FrictionLimit = 4.0f;

        public Vector2 Position, Velocity;

        public readonly Bitmap Bitmap;
        public readonly Vector2 Size;

        public bool OnGround { get; private set; }

        public Actor(Bitmap bitmap)
        {
            Bitmap = bitmap;
            Size = new Vector2(bitmap.Width, bitmap.Height);

            Position = new Vector2();
            Velocity = new Vector2();
        }

        public override void OnUpdate(EntityManager entityManager)
        {
            Velocity.X = MathUtilities.Clamp(Velocity.X, -FrictionLimit, FrictionLimit);
            Velocity.Y = MathUtilities.Clamp(Velocity.Y += Gravity, -GravityLimit, GravityLimit);

            TileMap map = entityManager.GetEntitiesByType<TileMap>()[0];

            Vector2 nextPosition = Position + new Vector2(Velocity.X, 0.0f), newPosition = new Vector2(Position);
            Vector2 sizeX = new Vector2(Size.X, 0.0f), sizeY = new Vector2(0.0f, Size.Y);

            if (map.CheckCollision(nextPosition))
            {
                newPosition.X = (float) Math.Floor(Position.X / Size.X) * Size.X;
                Velocity.X = 0;
            }
            else if (map.CheckCollision(nextPosition + sizeX))
            {
                newPosition.X = (float) Math.Ceiling(Position.X / Size.X) * Size.X;
                Velocity.X = 0;
            }
            else newPosition.X += Velocity.X;

            Velocity.X += Math.Abs(Velocity.X) < 0.5f ? 0.0f : Velocity.X < 0.0f ? Friction : -Friction;
            nextPosition = Position + new Vector2(0.0f, Velocity.Y);

            if (map.CheckCollision(nextPosition))
            {
                newPosition.Y = (float) Math.Floor(Position.Y / Size.Y) * Size.Y;
                Velocity.Y = 0;
            }
            else if (map.CheckCollision(nextPosition + sizeY))
            {
                OnGround = true;

                newPosition.Y = (float) Math.Ceiling(Position.Y / Size.Y) * Size.Y;
                Velocity.Y = 0;
            }
            else
            {
                OnGround = false;
                newPosition.Y += Velocity.Y;
            }

            Position.X = newPosition.X;
            Position.Y = newPosition.Y;

            SwinGame.DrawBitmap(Bitmap, Position.X, Position.Y);
        }
    }
}