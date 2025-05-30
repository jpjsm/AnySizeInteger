using System.Reflection;

namespace AnySizeInt.Tests
{
    public partial class AnySizeIntegerConstructors
    {
        #region Int constructors
        [Fact]
        public void TestSByteConstructorZero()
        {
            sbyte argument = 0;
            AnySizeInteger observed = new AnySizeInteger(argument);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Default constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0UL, $"Default constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"Default constructor returns negative for zero");
            Assert.True(hashcode == argument, $"Default constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestSByteConstructorOne()
        {
            sbyte argument = 1;
            AnySizeInteger observed = new AnySizeInteger(argument);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Default constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 1UL, $"Default constructor value different than one; received value is {digits[0]}");
            Assert.False(negative, $"Default constructor returns negative for one");
            Assert.True(hashcode == argument, $"Default constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestSByteConstructorMinusOne()
        {
            sbyte argument = -1;
            AnySizeInteger observed = new AnySizeInteger(argument);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Default constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 1UL, $"Default constructor value different than one; received value is {digits[0]}");
            Assert.True(negative, $"Default constructor returns positive for minus one");
            Assert.True(hashcode == 1, $"Default constructor hashcode value different than 1; received value is {hashcode}");
        }

        [Fact]
        public void TestSByteConstructorMaxValue()
        {
            AnySizeInteger observed = new AnySizeInteger(sbyte.MaxValue);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == (ulong)sbyte.MaxValue, $"'sbyte.MaxValue' constructor value different than {sbyte.MaxValue}; received value is {digits[0]}");
            Assert.False(negative, $"Default constructor returns negative for int.MaxValue");
            Assert.True(hashcode == sbyte.MaxValue, $"Default constructor hashcode value different than int.MaxValue; received value is {hashcode}");
        }

        [Fact]
        public void TestSByteConstructorMinValue()
        {
            AnySizeInteger observed = new AnySizeInteger(sbyte.MinValue);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == (ulong)sbyte.MaxValue + 1UL, $"Constructor value different than one; received value is {digits[0]}");
            Assert.True(negative, $"Constructor returns negative for int.MaxValue");
            Assert.True(hashcode == sbyte.MaxValue + 1, $"'sbyte.MinValue' constructor hashcode value different than {sbyte.MinValue}; received value is {hashcode}");
        }

        [Fact]
        public void TestSByteConstructorRandomValues()
        {
            sbyte[] randoms = [
                -65,
                -118,
                -10,
                107,
                9,
                sbyte.MinValue + 1,
                sbyte.MinValue
            ];
            foreach (sbyte rnd in randoms)
            {
                bool expectedNegative = rnd < 0;
                ulong expectedDigits0 = expectedNegative ? (ulong)(-((long)rnd)) : (ulong)rnd;
                int expectedHashcode = (int)expectedDigits0;

                AnySizeInteger observed = new AnySizeInteger(rnd);
                var (digits, negative, hashcode) = observed.GetInners();
                Assert.True(digits.Length == 1, $"Constructor Len different than 1; received length is {digits.Length}");
                Assert.True(digits[0] == expectedDigits0, $"Constructor value different than expected {expectedDigits0}; received value is {digits[0]}; rnd value {rnd}");
                Assert.True(negative == expectedNegative, $"Constructor returns different negative than expected {expectedNegative}");
                Assert.True(hashcode == expectedHashcode, $"Constructor hashcode value different than {expectedHashcode}; received value is {hashcode}");
            }

        }
        #endregion
    }
}
