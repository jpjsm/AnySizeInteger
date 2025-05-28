using System.Reflection;

namespace AnySizeInt.Tests
{
    public partial class AnySizeIntegerConstructors
    {
        #region Int constructors
        [Fact]
        public void TestIntConstructorZero()
        {
            AnySizeInteger observed = new AnySizeInteger(0);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Default constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0UL, $"Default constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"Default constructor returns negative for zero");
            Assert.True(hashcode == 0, $"Default constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestIntConstructorOne()
        {
            AnySizeInteger observed = new AnySizeInteger(1);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Default constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 1UL, $"Default constructor value different than one; received value is {digits[0]}");
            Assert.False(negative, $"Default constructor returns negative for one");
            Assert.True(hashcode == 1, $"Default constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestIntConstructorMinusOne()
        {
            AnySizeInteger observed = new AnySizeInteger(-1);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Default constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 1UL, $"Default constructor value different than one; received value is {digits[0]}");
            Assert.True(negative, $"Default constructor returns positive for minus one");
            Assert.True(hashcode == 1, $"Default constructor hashcode value different than 1; received value is {hashcode}");
        }

        [Fact]
        public void TestIntConstructorMaxValue()
        {
            AnySizeInteger observed = new AnySizeInteger(int.MaxValue);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Default constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == (ulong)int.MaxValue, $"Default constructor value different than int.MaxValue; received value is {digits[0]}");
            Assert.False(negative, $"Default constructor returns negative for int.MaxValue");
            Assert.True(hashcode == int.MaxValue, $"Default constructor hashcode value different than int.MaxValue; received value is {hashcode}");
        }

        [Fact]
        public void TestIntConstructorMinValue()
        {
            AnySizeInteger observed = new AnySizeInteger(int.MinValue);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0x80000000UL, $"Constructor value different than one; received value is {digits[0]}");
            Assert.True(negative, $"Constructor returns negative for int.MaxValue");
            Assert.True(hashcode == int.MinValue, $"Default constructor hashcode value different than int.MinValue; received value is {hashcode}");
        }

        [Fact]
        public void TestIntConstructorRandomValues()
        {
            int[] randoms = [
                -16214999,
                453781955,
                -1670152371,
                1961199009,
                -235879191,
                int.MinValue + 1,
                int.MinValue
            ];
            foreach (int rnd in randoms)
            {
                bool expectedNegative = rnd < 0;
                ulong expectedDigits0 = expectedNegative ? (ulong)(-((long)rnd)) : (ulong)rnd;
                int expectedHashcode = rnd == int.MinValue? int.MinValue : (int)expectedDigits0;

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
