namespace AnySizeInt.Tests
{
    public partial class AnySizeIntegerConstructors
    {
        #region String Constructor
        [Fact]
        public void TestAnySizeIntegerConstructorNull()
        {
            AnySizeInteger? argument = null;
            AnySizeInteger observed = new(argument);

            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Null AnySizeInteger constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0UL, $"Null AnySizeInteger constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"Null AnySizeInteger constructor returns negative for zero");
            Assert.True(hashcode == 0, $"Null AnySizeInteger constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestAnySizeIntegerConstructorZero()
        {
            AnySizeInteger? argument = AnySizeInteger.Zero;
            AnySizeInteger observed = new(argument);

            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Zero string constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0UL, $"Zero string constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"Zero string constructor returns negative for zero");
            Assert.True(hashcode == 0, $"Zero string constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestAnySizeIntegerConstructorOne()
        {
            AnySizeInteger? argument = AnySizeInteger.One;
            AnySizeInteger observed = new(argument);

            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"One string constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 1UL, $"One string constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"One string constructor returns negative for zero");
            Assert.True(hashcode == 1, $"One string constructor hashcode value different than one; received value is {hashcode}");
        }

        [Fact]
        public void TestAnySizeIntegerConstructorMinusOne()
        {
            AnySizeInteger? argument = AnySizeInteger.MinusOne;
            AnySizeInteger observed = new(argument);

            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"MinusOne string constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 1UL, $"MinusOne string constructor value different than zero; received value is {digits[0]}");
            Assert.True(negative, $"MinusOne string constructor returns negative for zero");
            Assert.True(hashcode == 1, $"MinusOne string constructor hashcode value different than one; received value is {hashcode}");
        }

        [Fact]
        public void TestAnySizeIntegerConstructor1111AnySizeIntegerDigits()
        {
            AnySizeInteger? argument = new AnySizeInteger("79228162532711081671548469249");
            AnySizeInteger observed = new(argument);

            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 4, $"1111AnySizeIntegerDigits string constructor Len different than 1; received length is {digits.Length}");
            Assert.True((digits[0] == 1UL) && (digits[1] == 1UL) && (digits[2] == 1UL) && (digits[3] == 1UL), $"1111AnySizeIntegerDigits string constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"1111AnySizeIntegerDigits string constructor returns negative for 1111AnySizeIntegerDigits");
            Assert.True(hashcode == 0, $"1111AnySizeIntegerDigits string constructor hashcode value different than one; received value is {hashcode}");
        }

        [Fact]
        public void TestAnySizeIntegerConstructor9876543210AnySizeIntegerDigits()
        {
            AnySizeInteger? argument = new AnySizeInteger("4475909128614416493485689423417672529955905318382457129602946176313508885239553977221120");
            AnySizeInteger observed = new(argument);

            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 10, $"9876543210AnySizeIntegerDigits string constructor Len different than 1; received length is {digits.Length}");
            Assert.True(
                ((digits[0] == 0UL) &&
                 (digits[1] == 1UL) &&
                 (digits[2] == 2UL) &&
                 (digits[3] == 3UL) &&
                 (digits[4] == 4UL) &&
                 (digits[5] == 5UL) &&
                 (digits[6] == 6UL) &&
                 (digits[7] == 7UL) &&
                 (digits[8] == 8UL) &&
                 (digits[9] == 9UL)),
                $"9876543210AnySizeIntegerDigits string constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"9876543210AnySizeIntegerDigits string constructor returns negative for 1111AnySizeIntegerDigits");
            Assert.True(hashcode == 1, $"1111AnySizeIntegerDigits string constructor hashcode value different than one; received value is {hashcode}");
        }

        [Fact]
        public void TestAnySizeIntegerConstructorRandomValues()
        {
            string[] randoms = [
                "-3855297896",
                "923104573",
                "-1967528843",
                "1859722262",
                "-1265700715"
            ];
            foreach (string rnd_str in randoms)
            {
                long rnd = Convert.ToInt64(rnd_str);
                bool expectedNegative = rnd < 0;
                ulong expectedDigits0 = expectedNegative ? (ulong)(-((long)rnd)) : (ulong)rnd;
                int expectedHashcode = (int)expectedDigits0;

                AnySizeInteger? argument = new AnySizeInteger(rnd_str);
                AnySizeInteger observed = new AnySizeInteger(argument);
                var (digits, negative, hashcode) = observed.GetInners();
                Assert.True(digits.Length == 1, $"'{rnd_str}' Constructor Len different than 1; received length is {digits.Length}");
                Assert.True(digits[0] == expectedDigits0, $"'{rnd_str}' Constructor value different than expected {expectedDigits0}; received value is {digits[0]}; rnd value {rnd}");
                Assert.True(negative == expectedNegative, $"'{rnd_str}' Constructor returns different negative than expected {expectedNegative}");
                Assert.True(hashcode == expectedHashcode, $"'{rnd_str}' Constructor hashcode value different than {expectedHashcode}; received value is {hashcode}");
            }
        }
        #endregion
    }
}
