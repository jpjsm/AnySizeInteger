namespace AnySizeInt.Tests
{
    public partial class AnySizeIntegerConstructors
    {
        #region String Constructor
        [Fact]
        public void TestStringConstructorNull()
        {
            string? argument = null;
            AnySizeInteger observed = new(argument);

            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Null string constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0UL, $"Null string constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"Null string constructor returns negative for zero");
            Assert.True(hashcode == 0, $"Null string constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestStringConstructorEmpty()
        {
            string? argument = "";
            AnySizeInteger observed = new(argument);

            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Empty string constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0UL, $"Empty string constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"Empty string constructor returns negative for zero");
            Assert.True(hashcode == 0, $"Empty string constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestStringConstructorWhiteSpaces()
        {
            string? argument = "\t  \t";
            AnySizeInteger observed = new(argument);

            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"WhiteSpaces string constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0UL, $"WhiteSpaces string constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"WhiteSpaces string constructor returns negative for zero");
            Assert.True(hashcode == 0, $"WhiteSpaces string constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestStringConstructorZero()
        {
            string? argument = "0";
            AnySizeInteger observed = new(argument);

            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Zero string constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0UL, $"Zero string constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"Zero string constructor returns negative for zero");
            Assert.True(hashcode == 0, $"Zero string constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestStringConstructorMinusZero()
        {
            string? argument = "-0";
            AnySizeInteger observed = new(argument);

            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"MinusZero string constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0UL, $"MinusZero string constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"MinusZero string constructor returns negative for zero");
            Assert.True(hashcode == 0, $"MinusZero string constructor hashcode value different than zero; received value is {hashcode}");
        }

        [Fact]
        public void TestStringConstructorOne()
        {
            string? argument = "1";
            AnySizeInteger observed = new(argument);

            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"One string constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 1UL, $"One string constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"One string constructor returns negative for zero");
            Assert.True(hashcode == 1, $"One string constructor hashcode value different than one; received value is {hashcode}");
        }

        [Fact]
        public void TestStringConstructorMinusOne()
        {
            string? argument = "-1";
            AnySizeInteger observed = new(argument);

            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"MinusOne string constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 1UL, $"MinusOne string constructor value different than zero; received value is {digits[0]}");
            Assert.True(negative, $"MinusOne string constructor returns negative for zero");
            Assert.True(hashcode == 1, $"MinusOne string constructor hashcode value different than one; received value is {hashcode}");
        }
        #endregion
    }
}
