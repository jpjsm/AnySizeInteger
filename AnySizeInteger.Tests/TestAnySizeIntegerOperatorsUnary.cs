using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnySizeIntegerUnitTestSuite
{
    using System.Reflection;
    using Katedra;

    [TestClass]
    public class TestAnySizeIntegerOperatorsUnary
    {
        #region Unary negation
        [TestMethod]
        public void TestUnaryNegationOne()
        {
            AnySizeInteger one = new AnySizeInteger(1);
            AnySizeInteger expected = new AnySizeInteger(-1);
            Assert.IsTrue(expected == -one, "'One' test failed");
        }

        [TestMethod]
        public void TestUnaryNegationMinusOne()
        {
            AnySizeInteger minusOne = new AnySizeInteger(-1);
            AnySizeInteger expected = new AnySizeInteger(1);
            Assert.IsTrue(expected == -minusOne, "'Minus One' test failed");
        }

        [TestMethod]
        public void TestUnaryNegationZero()
        {
            AnySizeInteger zero = new AnySizeInteger(0);
            AnySizeInteger expected = new AnySizeInteger(0);
            Assert.IsTrue(expected == -zero, "'Zero' test failed");
        }

        [TestMethod]
        public void TestUnaryNegationAnyNumber()
        {

            AnySizeInteger zero = new AnySizeInteger(0);
            AnySizeInteger expected = new AnySizeInteger(0);
            Assert.IsTrue(expected == -zero, "'Zero' test failed");
        }

        #endregion
    }
}
