using System.Reflection;

namespace AnySizeInt.Tests
{
    public class AnySizeIntegerConstructors
    {
        #region UInt constructors
        [Fact]
        public void TestUintConstructorZero()
        {
            uint z = 0;
            AnySizeInteger zero = new AnySizeInteger(z);
            Assert.True(zero.IsPositive(), "UInt constructor returns negative for zero");
            Assert.True(zero.Len() == 1, "UInt constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(zero);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 1, "Digits size different than 1");
            Assert.True(digitsValue[0] == 0, "UInt constructor returns different than zero");
        }

        [Fact]
        public void TestUintConstructorOne()
        {
            uint o = 1;
            AnySizeInteger one = new AnySizeInteger(o);
            Assert.True(one.IsPositive(), "UInt constructor returns negative for positive one");
            Assert.True(one.Len() == 1, "UInt constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(one);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 1, "Digits size different than 1");
            Assert.True(digitsValue[0] == 1, "UInt constructor returns different than positive one");
        }

        [Fact]
        public void TestUintConstructorMaxValue()
        {
            AnySizeInteger maxvalue = new AnySizeInteger(uint.MaxValue);
            Assert.True(maxvalue.IsPositive(), "UInt constructor returns negative for positive value");
            Assert.True(maxvalue.Len() == 1, "UInt constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(maxvalue);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 1, "Digits size different than 1");
            Assert.True(digitsValue[0] == uint.MaxValue, "UInt constructor returns different than positive MaxValue");
        }
        #endregion

        #region Ushort constructors
        [Fact]
        public void TestUshortConstructorZero()
        {
            ushort z = 0;
            AnySizeInteger zero = new AnySizeInteger(z);
            Assert.True(zero.IsPositive(), "UShort constructor returns negative for zero");
            Assert.True(zero.Len() == 1, "UShort constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(zero);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 1, "Digits size different than 1");
            Assert.True(digitsValue[0] == 0, "UShort constructor returns different than zero");
        }

        [Fact]
        public void TestUshortConstructorOne()
        {
            ushort o = 1;
            AnySizeInteger one = new AnySizeInteger(o);
            Assert.True(one.IsPositive(), "UShort constructor returns negative for positive one");
            Assert.True(one.Len() == 1, "UShort constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(one);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 1, "Digits size different than 1");
            Assert.True(digitsValue[0] == 1, "UShort constructor returns different than positive one");
        }

        [Fact]
        public void TestUshortConstructorMaxValue()
        {
            AnySizeInteger maxvalue = new AnySizeInteger(ushort.MaxValue);
            Assert.True(maxvalue.IsPositive(), "UShort constructor returns negative for positive value");
            Assert.True(maxvalue.Len() == 1, "UShort constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(maxvalue);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 1, "Digits size different than 1");
            Assert.True(digitsValue[0] == (uint)ushort.MaxValue, "UShort constructor returns different than positive MaxValue");
        }
        #endregion

        #region Byte constructors
        [Fact]
        public void TestByteConstructorZero()
        {
            byte z = 0;
            AnySizeInteger zero = new AnySizeInteger(z);
            Assert.True(zero.IsPositive(), "Byte constructor returns negative for zero");
            Assert.True(zero.Len() == 1, "Byte constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(zero);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 1, "Digits size different than 1");
            Assert.True(digitsValue[0] == 0, "Byte constructor returns different than zero");
        }

        [Fact]
        public void TestByteConstructorOne()
        {
            ushort o = 1;
            AnySizeInteger one = new AnySizeInteger(o);
            Assert.True(one.IsPositive(), "Byte constructor returns negative for positive one");
            Assert.True(one.Len() == 1, "Byte constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(one);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 1, "Digits size different than 1");
            Assert.True(digitsValue[0] == 1, "Byte constructor returns different than positive one");
        }

        [Fact]
        public void TestByteConstructorMaxValue()
        {
            AnySizeInteger maxvalue = new AnySizeInteger(byte.MaxValue);
            Assert.True(maxvalue.IsPositive(), "Byte constructor returns negative for positive value");
            Assert.True(maxvalue.Len() == 1, "Byte constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(maxvalue);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 1, "Digits size different than 1");
            Assert.True(digitsValue[0] == (uint)byte.MaxValue, "UShort constructor returns different than positive MaxValue");
        }
        #endregion

        #region Long constructors
        [Fact]
        public void TestLongConstructorZero()
        {
            AnySizeInteger zero = new AnySizeInteger(0L);
            Assert.True(zero.IsPositive(), "Long constructor returns negative for zero");
            Assert.True(zero.Len() == 1, "Long constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(zero);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 1, "Digits size different than 1");
            Assert.True(digitsValue[0] == 0, "Long constructor returns different than zero");
        }

        [Fact]
        public void TestLongConstructorOne()
        {
            AnySizeInteger one = new AnySizeInteger(1L);
            Assert.True(one.IsPositive(), "Long constructor returns negative for positive one");
            Assert.True(one.Len() == 1, "Long constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(one);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 1, "Digits size different than 1");
            Assert.True(digitsValue[0] == 1, "Long constructor returns different than positive one");
        }

        [Fact]
        public void TestLongConstructorMinusOne()
        {
            AnySizeInteger minusone = new AnySizeInteger(-1L);
            Assert.True(minusone.IsNegative(), "Long constructor returns positive for negative one");
            Assert.True(minusone.Len() == 1, "Long constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(minusone);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 1, "Digits size different than 1");
            Assert.True(digitsValue[0] == 1, "Long constructor returns different than positive one");
        }

        [Fact]
        public void TestLongConstructorMaxValue()
        {
            AnySizeInteger maxvalue = new AnySizeInteger(long.MaxValue);
            Assert.True(maxvalue.IsPositive(), "Long constructor returns negative for positive value");
            Assert.True(maxvalue.Len() == 2, "Long constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(maxvalue);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 2, "Digits size different than 1");
            Assert.True(digitsValue[0] == uint.MaxValue && digitsValue[1] == int.MaxValue, "Long constructor returns different than positive MaxValue");
        }

        [Fact]
        public void TestLongConstructorMinValue()
        {
            AnySizeInteger minvalue = new AnySizeInteger(long.MinValue);
            Assert.True(minvalue.IsNegative(), "Int constructor returns positive for negative value");
            Assert.True(minvalue.Len() == 3, "Int constructor Len different than 2");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(minvalue);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 3, "Digits size different than 2");
            Assert.True(digitsValue[0] == 0 && digitsValue[1] == 0 && digitsValue[2] == 1, "Int constructor returns different than positive MinValue");
        }
        #endregion

        #region Ulong constructors
        [Fact]
        public void TestULongConstructorZero()
        {
            ulong z = 0UL;
            AnySizeInteger zero = new AnySizeInteger(z);
            Assert.True(zero.IsPositive(), "ULong constructor returns negative for zero");
            Assert.True(zero.Len() == 1, "ULong constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(zero);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 1, "Digits size different than 1");
            Assert.True(digitsValue[0] == 0U, "ULong constructor returns different than zero");
        }

        [Fact]
        public void TestUlongConstructorOne()
        {
            ulong o = 1UL;
            AnySizeInteger one = new AnySizeInteger(o);
            Assert.True(one.IsPositive(), "ULong constructor returns negative for positive one");
            Assert.True(one.Len() == 1, "ULong constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(one);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 1, "Digits size different than 1");
            Assert.True(digitsValue[0] == 1, "ULong constructor returns different than positive one");
        }

        [Fact]
        public void TestUlongConstructorMaxValue()
        {
            AnySizeInteger maxvalue = new AnySizeInteger(ulong.MaxValue);
            Assert.True(maxvalue.IsPositive(), "ULong constructor returns negative for positive value");
            Assert.True(maxvalue.Len() == 2, "ULong constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(maxvalue);

            Assert.NotNull(digitsValue, "Reflection couldn't get digits");
            Assert.True(digitsValue.Length == 2, "Digits size different than 1");
            Assert.True(digitsValue[0] == uint.MaxValue && digitsValue[1] == uint.MaxValue, "ULong constructor returns different than positive MaxValue");
        }
        #endregion
    }
}
