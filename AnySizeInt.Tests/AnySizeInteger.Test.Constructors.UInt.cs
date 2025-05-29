using System.Reflection;

namespace AnySizeInt.Tests
{
    public partial class AnySizeIntegerConstructors
    {
        #region Int constructors
        [Fact]
        public void TestUIntConstructorZero()
        {
            uint argument = 0;
            AnySizeInteger observed = new AnySizeInteger(argument);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Default constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0UL, $"Default constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"Default constructor returns negative for zero");
            Assert.True(hashcode == 0, $"Default constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestUIntConstructorOne()
        {
            uint argument = 1;
            AnySizeInteger observed = new AnySizeInteger(argument);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Default constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 1UL, $"Default constructor value different than one; received value is {digits[0]}");
            Assert.False(negative, $"Default constructor returns negative for one");
            Assert.True(hashcode == 1, $"Default constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestUIntConstructorMaxValue()
        {
            AnySizeInteger observed = new AnySizeInteger(uint.MaxValue);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"'uint.MaxValue' constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == (ulong)uint.MaxValue, $"'uint.MaxValue' constructor value different than int.MaxValue; received value is {digits[0]}");
            Assert.False(negative, $"'uint.MaxValue' constructor returns negative for uint.MaxValue");
            Assert.True(hashcode == -1, $"'uint.MaxValue' constructor hashcode value different than {uint.MaxValue}; received value is {hashcode}");
        }

        [Fact]
        public void TestUIntConstructorMinValue()
        {
            AnySizeInteger observed = new AnySizeInteger(uint.MinValue);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == uint.MinValue, $"Constructor value different than one; received value is {digits[0]}");
            Assert.False(negative, $"Constructor returns negative for uint.MinValue");
            Assert.True(hashcode == uint.MinValue, $"'uint.MinValue' constructor hashcode value different than {uint.MinValue}; received value is {hashcode}");
        }

        [Fact]
        public void TestUIntConstructorRandomValues()
        {
            uint[] randoms = [
                217973397,
                2045152834,
                1302779479,
                22032638,
                448597527,
                uint.MinValue + 1,
                uint.MinValue
            ];
            foreach (uint rnd in randoms)
            {
                bool expectedNegative = rnd < 0;
                ulong expectedDigits0 = expectedNegative ? (ulong)(-((long)rnd)) : (ulong)rnd;
                int expectedHashcode = rnd == uint.MinValue? (int)uint.MinValue : (int)expectedDigits0;

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
