using System.Reflection;
using AnySizeInt;

namespace AnySizeInt.Tests
{
    public class TestAnySizeIntegerOperatorsUnary
    {
        #region Unary negation
        [Fact]
        public void TestUnaryNegationOne()
        {
            AnySizeInteger one = new AnySizeInteger(1);
            AnySizeInteger expected = new AnySizeInteger(-1);
            Assert.IsTrue(expected == -one, "'One' test failed");
        }

        [Fact]
        public void TestUnaryNegationMinusOne()
        {
            AnySizeInteger minusOne = new AnySizeInteger(-1);
            AnySizeInteger expected = new AnySizeInteger(1);
            Assert.IsTrue(expected == -minusOne, "'Minus One' test failed");
        }

        [Fact]
        public void TestUnaryNegationZero()
        {
            AnySizeInteger zero = new AnySizeInteger(0);
            AnySizeInteger expected = new AnySizeInteger(0);
            Assert.IsTrue(expected == -zero, "'Zero' test failed");
        }

        [Fact]
        public void TestUnaryNegationAnyNumber()
        {

            AnySizeInteger zero = new AnySizeInteger(0);
            AnySizeInteger expected = new AnySizeInteger(0);
            Assert.IsTrue(expected == -zero, "'Zero' test failed");
        }

        #endregion
    }
}
