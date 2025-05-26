using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnySizeIntegerUnitTestSuite
{
    using System.Reflection;
    using Katedra;

    [TestClass]
    public class TestAnySizeIntegerPublicMethods
    {
        #region Uint2Int
        [TestMethod]
        public void TestUint2IntZero()
        {
            Assert.IsTrue(AnySizeInteger.Uint2Int(0U) == 0, "'Zero' test failed");
        }

        [TestMethod]
        public void TestUint2IntOne()
        {
            Assert.IsTrue(AnySizeInteger.Uint2Int(1U) == 1, "'One' test failed");
        }

        [TestMethod]
        public void TestUint2IntMaxValue()
        {
            Assert.IsTrue(AnySizeInteger.Uint2Int(uint.MaxValue) == -1, "'MaxValue' test failed");
        }

        [TestMethod]
        public void TestUint2IntHighestBitOn()
        {
            Assert.IsTrue(AnySizeInteger.Uint2Int(0x80000000U) == int.MinValue, "'HighestBitOn' test failed");
        }

        [TestMethod]
        public void TestUint2IntNegativeValues()
        {
            const uint highestBitOn = 0x80000000U;
            uint testvalue;
            int expected;
            for (uint i = 0U; i < 0x100; i++)
            {
                testvalue = highestBitOn + i;
                expected = int.MinValue + (int)i;
                Assert.IsTrue(AnySizeInteger.Uint2Int(testvalue) == expected, "'Negative values' test failed");
            }
        }
        #endregion

        #region Len
        // ToDo: Add Len unit tests
        #endregion

        #region IsPositive
        // ToDo: Add IsPositive unit tests
        #endregion

        #region IsNegative
        // ToDo: Add IsNegative unit tests
        #endregion
    }
}
