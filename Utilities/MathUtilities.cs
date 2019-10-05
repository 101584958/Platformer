using System;

namespace Template.Utilities
{
    public class MathUtilities
    {
        private static Random _random = new Random();

        public static int Random(int minimum, int maximum)
        {
            return _random.Next(minimum, maximum);
        }

        public static T Clamp<T>(T value, T minimum, T maximum) where T : IComparable<T>
        {
            return value.CompareTo(minimum) < 0 ? minimum : value.CompareTo(maximum) > 0 ? maximum : value;
        }
    }
}