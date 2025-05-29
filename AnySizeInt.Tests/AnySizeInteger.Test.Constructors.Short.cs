using System.Reflection;

namespace AnySizeInt.Tests
{
    public partial class AnySizeIntegerConstructors
    {
        #region Int constructors
        [Fact]
        public void TestShortConstructorZero()
        {
            short argument = 0;
            AnySizeInteger observed = new AnySizeInteger(argument);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Default constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0UL, $"Default constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"Default constructor returns negative for zero");
            Assert.True(hashcode == argument, $"Default constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestShortConstructorOne()
        {
            short argument = 1;
            AnySizeInteger observed = new AnySizeInteger(argument);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Default constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 1UL, $"Default constructor value different than one; received value is {digits[0]}");
            Assert.False(negative, $"Default constructor returns negative for one");
            Assert.True(hashcode == argument, $"Default constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestShortConstructorMinusOne()
        {
            short argument = -1;
            AnySizeInteger observed = new AnySizeInteger(argument);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Default constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 1UL, $"Default constructor value different than one; received value is {digits[0]}");
            Assert.True(negative, $"Default constructor returns positive for minus one");
            Assert.True(hashcode == 1, $"Default constructor hashcode value different than 1; received value is {hashcode}");
        }

        [Fact]
        public void TestShortConstructorMaxValue()
        {
            AnySizeInteger observed = new AnySizeInteger(short.MaxValue);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == (ulong)short.MaxValue, $"'short.MaxValue' constructor value different than {short.MaxValue}; received value is {digits[0]}");
            Assert.False(negative, $"Default constructor returns negative for int.MaxValue");
            Assert.True(hashcode == short.MaxValue, $"Default constructor hashcode value different than int.MaxValue; received value is {hashcode}");
        }

        [Fact]
        public void TestShortConstructorMinValue()
        {
            AnySizeInteger observed = new AnySizeInteger(short.MinValue);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == (ulong)short.MaxValue + 1UL, $"Constructor value different than one; received value is {digits[0]}");
            Assert.True(negative, $"Constructor returns negative for int.MaxValue");
            Assert.True(hashcode == short.MaxValue + 1, $"'short.MinValue' constructor hashcode value different than {short.MinValue}; received value is {hashcode}");
        }

        [Fact]
        public void TestShortConstructorRandomValues()
        {
            short[] randoms = [
                -26931,
                16625,
                -27406,
                22918,
                -4285,
                short.MinValue + 1,
                short.MinValue
            ];
            foreach (short rnd in randoms)
            {
                bool expectedNegative = rnd < 0;
                ulong expectedDigits0 = expectedNegative ? (ulong)(-((long)rnd)) : (ulong)rnd;
                int expectedHashcode = (int)expectedDigits0;

                AnySizeInteger observed = new AnySizeInteger(rnd);
                var (digits, negative, hashcode) = observed.GetInners();
                Assert.True(digits.Length == 1, $"'{rnd}' Constructor Len different than 1; received length is {digits.Length}");
                Assert.True(digits[0] == expectedDigits0, $"'{rnd}' Constructor value different than expected {expectedDigits0}; received value is {digits[0]}; rnd value {rnd}");
                Assert.True(negative == expectedNegative, $"'{rnd}' Constructor returns different negative than expected {expectedNegative}");
                Assert.True(hashcode == expectedHashcode, $"'{rnd}' Constructor hashcode value different than {expectedHashcode}; received value is {hashcode}");
            }

        }
        #endregion
    }
}
