using SwinGameSDK;
using System;

namespace Template.Utilities
{
    public interface ICollidable
    {
        Vector2 Position { get; }
        Vector2 Size { get; }
    }

    public static class Collision
    {
        public static Vector2 CheckCollision(ICollidable lhs, ICollidable rhs)
        {
            float left = lhs.Position.X - (rhs.Position.X + rhs.Size.X);
            float right = left + lhs.Size.X + rhs.Size.X;

            float top = lhs.Position.Y - (rhs.Position.Y + rhs.Size.Y);
            float bottom = top + lhs.Size.Y + rhs.Size.Y;

            if (SwinGame.PointInRect(0, 0, left, top, right - left, bottom - top))
            {
                float minimumDistance = Math.Abs(0 - left);
                Vector2 penetrationVector = new Vector2(left, 0);

                if (Math.Abs(right - 0) < minimumDistance)
                {
                    minimumDistance = Math.Abs(right - 0);
                    penetrationVector = new Vector2(right, 0);
                }

                if (Math.Abs(bottom - 0) < minimumDistance)
                {
                    minimumDistance = Math.Abs(bottom - 0);
                    penetrationVector = new Vector2(0, bottom);
                }

                if (Math.Abs(top - 0) < minimumDistance)
                {
                    minimumDistance = Math.Abs(top - 0);
                    penetrationVector = new Vector2(0, top);
                }

                return penetrationVector;
            }

            return null;
        }
    }
}
