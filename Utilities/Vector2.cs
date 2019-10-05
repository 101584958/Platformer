using SwinGameSDK;

namespace Template.Utilities
{
    public class Vector2
    {
        public float X, Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2(float value = 0.0f)
        {
            X = Y = value;
        }

        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2
            {
                X = left.X + right.X,
                Y = left.Y + right.Y
            };
        }

        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2
            {
                X = left.X - right.X,
                Y = left.Y - right.Y
            };
        }

        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            return new Vector2
            {
                X = left.X * right.X,
                Y = left.Y * right.Y
            };
        }

        public static Vector2 operator /(Vector2 left, Vector2 right)
        {
            return new Vector2
            {
                X = left.X / right.X,
                Y = left.Y / right.Y
            };
        }

        public static Vector2 operator +(Vector2 vector, float value)
        {
            return new Vector2
            {
                X = vector.X + value,
                Y = vector.Y + value
            };
        }

        public static Vector2 operator -(Vector2 vector, float value)
        {
            return new Vector2
            {
                X = vector.X - value,
                Y = vector.Y - value
            };
        }

        public static Vector2 operator *(Vector2 vector, float value)
        {
            return new Vector2
            {
                X = vector.X * value,
                Y = vector.Y * value
            };
        }

        public static Vector2 operator /(Vector2 vector, float value)
        {
            return new Vector2
            {
                X = vector.X / value,
                Y = vector.Y / value
            };
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;

            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            if (left == null && right == null) return false;
            if (left == null || right == null) return true;

            return left.X != right.X || left.Y != right.Y;
        }

        public static implicit operator Point2D(Vector2 vector)
        {
            return new Point2D
            {
                X = vector.X,
                Y = vector.Y
            };
        }
    }
}