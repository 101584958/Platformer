using Microsoft.VisualStudio.TestTools.UnitTesting;
using Template.Utilities;

namespace Template.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ApproximateEqualTrueTest()
        {
            float left = 5.0f, right = 10.0f;
            bool result = MathUtilities.ApproximatelyEqual(left, right, 5.0f);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ApproximateEqualFalseTest()
        {
            float left = 5.0f, right = 10.0f;
            bool result = MathUtilities.ApproximatelyEqual(left, right);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ClampMinimumTest()
        {
            float value = -10.0f, minimum = 0.0f, maximum = 1.0f;
            float result = MathUtilities.Clamp(value, minimum, maximum);

            Assert.AreEqual(0.0f, result);
        }

        [TestMethod]
        public void ClampMaximumTest()
        {
            float value = 10.0f, minimum = 0.0f, maximum = 1.0f;
            float result = MathUtilities.Clamp(value, minimum, maximum);

            Assert.AreEqual(1.0f, result);
        }

        [TestMethod]
        public void Vector2DefaultConstructerTest()
        {
            Vector2 vector = new Vector2();
            Assert.IsTrue(vector.X == 0.0f && vector.Y == 0.0f);
        }

        [TestMethod]
        public void Vector2OneValueConstructorTest()
        {
            Vector2 vector = new Vector2(5.0f);
            Assert.IsTrue(vector.X == 5.0f && vector.Y == 5.0f);
        }

        [TestMethod]
        public void Vector2TwoValueConstructorTest()
        {
            Vector2 vector = new Vector2(10.0f, 15.0f);
            Assert.IsTrue(vector.X == 10.0f && vector.Y == 15.0f);
        }

        [TestMethod]
        public void Vector2EqualTest()
        {
            Vector2 left = new Vector2(10.0f, 15.0f), right = new Vector2(10.0f, 15.0f);
            Assert.IsTrue(left == right);
        }

        [TestMethod]
        public void Vector2NotEqualTest()
        {
            Vector2 left = new Vector2(10.0f, 15.0f), right = new Vector2(15.0f, 10.0f);
            Assert.IsTrue(left != right);
        }
    }
}
