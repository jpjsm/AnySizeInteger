namespace AnySizeInt.Tests
{
    public partial class AnySizeIntegerConstructors
    {
        #region Default Constructor
        [Fact]
        public void TestDefaultConstructor()
        {
            AnySizeInteger observed = new();

            var (digits, negative, hashcode) = observed.GetInners();
            Assert.True(digits.Length == 1, $"Default constructor Len different than 1; received length is {digits.Length}");
            Assert.True(digits[0] == 0UL, $"Default constructor value different than zero; received value is {digits[0]}");
            Assert.False(negative, $"Default constructor returns negative for zero");
            Assert.True(hashcode == 0, $"Default constructor hashcode value different than zero; received value is {hashcode}");
        }
        #endregion
    }
}
