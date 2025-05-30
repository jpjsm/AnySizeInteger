using System.Reflection;

namespace AnySizeInt.Tests
{
    public partial class AnySizeIntegerConstructors
    {
        #region Int constructors
        [Fact]
        public void TestLongConstructorZero()
        {
            long argument = 0L;
            AnySizeInteger observed = new AnySizeInteger(argument);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"'0L' constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0UL, $"'0L'  constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"'0L'  constructor returns negative for zero");
            Assert.True(hashcode == argument, $"'0L' constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestLongConstructorOne()
        {
            long argument = 1L;
            AnySizeInteger observed = new AnySizeInteger(argument);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"'1L' constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 1UL, $"'1L' constructor value different than one; received value is {digits[0]}");
            Assert.False(negative, $"'1L' constructor returns negative for one");
            Assert.True(hashcode == argument, $"'1L' constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestLongConstructorMinusOne()
        {
            long argument = -1L;
            AnySizeInteger observed = new AnySizeInteger(argument);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"'-1L' constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 1UL, $"'-1L' constructor value different than one; received value is {digits[0]}");
            Assert.True(negative, $"'-1L' constructor returns positive for minus one");
            Assert.True(hashcode == 1, $"'-1L' constructor hashcode value different than 1; received value is {hashcode}");
        }

        [Fact]
        public void TestLongConstructorMaxValue()
        {
            AnySizeInteger observed = new AnySizeInteger(long.MaxValue);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 2, $"'long.MaxValue' Constructor Len different than 2; received length is {digits.Length}");
            Assert.True(digits[0] == (ulong)uint.MaxValue && digits[1] == (ulong)int.MaxValue, $"'long.MaxValue' constructor value different than [{uint.MaxValue}, {int.MaxValue}]; received value is [{digits[0]}, {digits[1]}]");
            Assert.False(negative, $"'long.MaxValue' constructor returns negative for int.MaxValue");
            Assert.True(hashcode == int.MinValue, $"'long.MaxValue' constructor hashcode value different than {int.MinValue}; received value is {hashcode}");
        }

        [Fact]
        public void TestLongConstructorMinValue()
        {
            AnySizeInteger observed = new AnySizeInteger(long.MinValue);
            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 3, $"'long.MinValue' Constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0 && digits[1] == 0 && digits[2] == 1, $"'long.MinValue' Constructor value different than one; received value is {digits[0]}");
            Assert.True(negative, $"'long.MinValue' Constructor returns negative for int.MaxValue");
            Assert.True(hashcode == 1, $"'long.MinValue' constructor hashcode value different than {long.MinValue}; received value is {hashcode}");
        }

        [Fact]
        public void TestLongConstructorRandomValues()
        {
            long[] randoms = [
                506294319579685660,
                -5105542371722031493,
                -4534537426277969161,
                -597515966931019537,
                1157763606680961624,
                23745660,
                5504248294435626152,
                -270794188,
                4886807245309993198,
                5123457357443478723,
                long.MinValue + 1
            ];
            foreach (long rnd in randoms)
            {
                bool expectedNegative = rnd < 0;
                ulong expectedDigit_0 = (expectedNegative ? (ulong)-rnd : (ulong)rnd) & 0xFFFFFFFFUL;
                ulong expectedDigit_1 = (expectedNegative ? (ulong)-rnd : (ulong)rnd) >> 32;
                bool doubledigit = expectedDigit_1 > 0;
                int expectedHashcode = (int)(expectedDigit_0 ^ expectedDigit_1);

                AnySizeInteger observed = new AnySizeInteger(rnd);
                var (digits, negative, hashcode) = observed.GetInners();
                Assert.True(digits.Length == (doubledigit ? 2 : 1), $"'{rnd}' Constructor Len different than {(doubledigit ? 2 : 1)}; received length is {digits.Length}");
                if (doubledigit)
                {
                    Assert.True(digits[0] == expectedDigit_0 && digits[1] == expectedDigit_1,
                            $"'{rnd}' Constructor value different than expected [{expectedDigit_0}, {expectedDigit_1}]; received value are [{digits[0]}, {digits[0]}].");
                }
                else
                {
                    Assert.True(digits[0] == expectedDigit_0,
                                $"'{rnd}' Constructor value different than expected {expectedDigit_0}; received value is {digits[0]}.");
                }
                Assert.True(negative == expectedNegative, $"'{rnd}' Constructor returns different negative than expected {expectedNegative}");
                Assert.True(hashcode == expectedHashcode, $"'{rnd}' Constructor hashcode value different than {expectedHashcode}; received value is {hashcode}");
            }

        }
        #endregion
    }
}
