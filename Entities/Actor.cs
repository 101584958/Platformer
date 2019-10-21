using System;
using System.Collections.Generic;
using SwinGameSDK;
using Template.Utilities;

namespace Template.Entities
{
    public abstract class Actor : Entity, ICollidable
    {
        public override int ZIndex { get; }

        private const float Gravity = 1.25f, GravityLimit = 16.0f;
        private const float Friction = 1.0f, FrictionLimit = 10.0f;

        public Vector2 Position { get; set; }
        public Vector2 Velocity;

        public readonly Bitmap Bitmap;
        public Vector2 Size { get; }

        public bool OnGround { get; protected set; }

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
            Velocity.X += Math.Abs(Velocity.X) < 0.5f ? 0.0f : Velocity.X < 0.0f ? Friction : -Friction;

            Velocity.Y = MathUtilities.Clamp(Velocity.Y += Gravity, -GravityLimit, GravityLimit);

            Position += Velocity;
            OnGround = false;

            OnCheckCollision(entityManager.GetEntitiesByType<Collider>());
        }

        public override void OnRender(EntityManager entityManager)
        {
            SwinGame.DrawBitmap(Bitmap, Position.X, Position.Y);
        }

        public virtual void OnCheckCollision(List<Collider> colliders)
        {
            foreach (Collider collider in colliders)
            {
                Vector2 penetrationVector = Collision.CheckCollision(this, collider);

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