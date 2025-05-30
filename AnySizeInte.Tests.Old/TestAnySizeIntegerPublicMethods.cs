using System.Reflection;
using AnySizeInt;

namespace AnySizeInt.Tests
{
    public class TestAnySizeIntegerPublicMethods
    {
        #region Uint2Int
        [Fact]
        public void TestUint2IntZero()
        {
            Assert.IsTrue(AnySizeInteger.Uint2Int(0U) == 0, "'Zero' test failed");
        }

        [Fact]
        public void TestUint2IntOne()
        {
            Assert.IsTrue(AnySizeInteger.Uint2Int(1U) == 1, "'One' test failed");
        }

        [Fact]
        public void TestUint2IntMaxValue()
        {
            Assert.IsTrue(AnySizeInteger.Uint2Int(uint.MaxValue) == -1, "'MaxValue' test failed");
        }

        [Fact]
        public void TestUint2IntHighestBitOn()
        {
            Assert.IsTrue(AnySizeInteger.Uint2Int(0x80000000U) == int.MinValue, "'HighestBitOn' test failed");
        }

        [Fact]
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
