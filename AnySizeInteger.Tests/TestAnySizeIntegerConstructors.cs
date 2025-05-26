using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AnySizeIntegerUnitTestSuite
{
    using System.Reflection;
    using Katedra;

    [TestClass]
    public class AnySizeIntegerConstructors
    {
        #region Default Constructor
        [TestMethod]
        public void TestDefaultConstructor()
        {
            AnySizeInteger foo = new AnySizeInteger();
            Assert.IsTrue(foo.IsPositive(), "Default constructor returns negative for zero");
            Assert.IsTrue(foo.Len() == 1, "Default constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(foo);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 0, "Default constructor returns different than zero");
        }
        #endregion

        #region Int constructors
        [TestMethod]
        public void TestIntConstructorZero()
        {
            AnySizeInteger zero = new AnySizeInteger(0);
            Assert.IsTrue(zero.IsPositive(), "Int constructor returns negative for zero");
            Assert.IsTrue(zero.Len() == 1, "Int constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(zero);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 0, "Int constructor returns different than zero");
        }

        [TestMethod]
        public void TestIntConstructorOne()
        {
            AnySizeInteger one = new AnySizeInteger(1);
            Assert.IsTrue(one.IsPositive(), "Int constructor returns negative for positive one");
            Assert.IsTrue(one.Len() == 1, "Int constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(one);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 1, "Int constructor returns different than positive one");
        }

        [TestMethod]
        public void TestIntConstructorMinusOne()
        {
            AnySizeInteger minusone = new AnySizeInteger(-1);
            Assert.IsTrue(minusone.IsNegative(), "Int constructor returns positive for negative one");
            Assert.IsTrue(minusone.Len() == 1, "Int constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(minusone);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 1, "Int constructor returns different than positive one");
        }

        [TestMethod]
        public void TestIntConstructorMaxValue()
        {
            AnySizeInteger maxvalue = new AnySizeInteger(int.MaxValue);
            Assert.IsTrue(maxvalue.IsPositive(), "Int constructor returns negative for positive value");
            Assert.IsTrue(maxvalue.Len() == 1, "Int constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(maxvalue);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == (uint)int.MaxValue, "Int constructor returns different than positive MaxValue");
        }

        [TestMethod]
        public void TestIntConstructorMinValue()
        {
            AnySizeInteger minvalue = new AnySizeInteger(int.MinValue);
            Assert.IsTrue(minvalue.IsNegative(), "Int constructor returns positive for negative value");
            Assert.IsTrue(minvalue.Len() == 1, "Int constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(minvalue);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 0x80000000, "Int constructor returns different than positive MinValue");
        }
        #endregion

        #region Short constructors
        [TestMethod]
        public void TestShortConstructorZero()
        {
            short z = 0;
            AnySizeInteger zero = new AnySizeInteger(z);
            Assert.IsTrue(zero.IsPositive(), "Int constructor returns negative for zero");
            Assert.IsTrue(zero.Len() == 1, "Int constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(zero);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 0, "Int constructor returns different than zero");
        }

        [TestMethod]
        public void TestShortConstructorOne()
        {
            short o = 1;
            AnySizeInteger one = new AnySizeInteger(o);
            Assert.IsTrue(one.IsPositive(), "Int constructor returns negative for positive one");
            Assert.IsTrue(one.Len() == 1, "Int constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(one);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 1, "Int constructor returns different than positive one");
        }

        [TestMethod]
        public void TestShortConstructorMinusOne()
        {
            short m = -1;
            AnySizeInteger minusone = new AnySizeInteger(m);
            Assert.IsTrue(minusone.IsNegative(), "Int constructor returns positive for negative one");
            Assert.IsTrue(minusone.Len() == 1, "Int constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(minusone);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 1, "Int constructor returns different than positive one");
        }

        [TestMethod]
        public void TestShortConstructorMaxValue()
        {
            AnySizeInteger maxvalue = new AnySizeInteger(short.MaxValue);
            Assert.IsTrue(maxvalue.IsPositive(), "Int constructor returns negative for positive value");
            Assert.IsTrue(maxvalue.Len() == 1, "Int constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(maxvalue);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == (uint)short.MaxValue, "Int constructor returns different than positive MaxValue");
        }

        [TestMethod]
        public void TestShortConstructorMinValue()
        {
            AnySizeInteger minvalue = new AnySizeInteger(short.MinValue);
            Assert.IsTrue(minvalue.IsNegative(), "Int constructor returns positive for negative value");
            Assert.IsTrue(minvalue.Len() == 1, "Int constructor Len different than 2");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(minvalue);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == (uint)(-((int)short.MinValue)), "Int constructor returns different than positive MinValue");
        }
        #endregion

        #region SByte constructors
        [TestMethod]
        public void TestSbyteConstructorZero()
        {
            sbyte z = 0;
            AnySizeInteger zero = new AnySizeInteger(z);
            Assert.IsTrue(zero.IsPositive(), "Sbyte constructor returns negative for zero");
            Assert.IsTrue(zero.Len() == 1, "Sbyte constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(zero);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 0, "Sbyte constructor returns different than zero");
        }

        [TestMethod]
        public void TestSbyteConstructorOne()
        {
            sbyte o = 1;
            AnySizeInteger one = new AnySizeInteger(o);
            Assert.IsTrue(one.IsPositive(), "Sbyte constructor returns negative for positive one");
            Assert.IsTrue(one.Len() == 1, "Sbyte constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(one);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 1, "Sbyte constructor returns different than positive one");
        }

        [TestMethod]
        public void TestSbyteConstructorMinusOne()
        {
            sbyte m = -1;
            AnySizeInteger minusone = new AnySizeInteger(m);
            Assert.IsTrue(minusone.IsNegative(), "Sbyte constructor returns positive for negative one");
            Assert.IsTrue(minusone.Len() == 1, "Sbyte constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(minusone);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 1, "Sbyte constructor returns different than positive one");
        }

        [TestMethod]
        public void TestSbyteConstructorMaxValue()
        {
            AnySizeInteger maxvalue = new AnySizeInteger(sbyte.MaxValue);
            Assert.IsTrue(maxvalue.IsPositive(), "Sbyte constructor returns negative for positive value");
            Assert.IsTrue(maxvalue.Len() == 1, "Sbyte constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(maxvalue);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == (uint)sbyte.MaxValue, "Sbyte constructor returns different than positive MaxValue");
        }

        [TestMethod]
        public void TestSbyteConstructorMinValue()
        {
            AnySizeInteger minvalue = new AnySizeInteger(sbyte.MinValue);
            Assert.IsTrue(minvalue.IsNegative(), "Sbyte constructor returns positive for negative value");
            Assert.IsTrue(minvalue.Len() == 1, "Sbyte constructor Len different than 2");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(minvalue);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == (uint)(-((int)sbyte.MinValue)), "Sbyte constructor returns different than positive MinValue");
        }
        #endregion

        #region UInt constructors
        [TestMethod]
        public void TestUintConstructorZero()
        {
            uint z = 0;
            AnySizeInteger zero = new AnySizeInteger(z);
            Assert.IsTrue(zero.IsPositive(), "UInt constructor returns negative for zero");
            Assert.IsTrue(zero.Len() == 1, "UInt constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(zero);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 0, "UInt constructor returns different than zero");
        }

        [TestMethod]
        public void TestUintConstructorOne()
        {
            uint o = 1;
            AnySizeInteger one = new AnySizeInteger(o);
            Assert.IsTrue(one.IsPositive(), "UInt constructor returns negative for positive one");
            Assert.IsTrue(one.Len() == 1, "UInt constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(one);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 1, "UInt constructor returns different than positive one");
        }

        [TestMethod]
        public void TestUintConstructorMaxValue()
        {
            AnySizeInteger maxvalue = new AnySizeInteger(uint.MaxValue);
            Assert.IsTrue(maxvalue.IsPositive(), "UInt constructor returns negative for positive value");
            Assert.IsTrue(maxvalue.Len() == 1, "UInt constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(maxvalue);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == uint.MaxValue, "UInt constructor returns different than positive MaxValue");
        }
        #endregion

        #region Ushort constructors
        [TestMethod]
        public void TestUshortConstructorZero()
        {
            ushort z = 0;
            AnySizeInteger zero = new AnySizeInteger(z);
            Assert.IsTrue(zero.IsPositive(), "UShort constructor returns negative for zero");
            Assert.IsTrue(zero.Len() == 1, "UShort constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(zero);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 0, "UShort constructor returns different than zero");
        }

        [TestMethod]
        public void TestUshortConstructorOne()
        {
            ushort o = 1;
            AnySizeInteger one = new AnySizeInteger(o);
            Assert.IsTrue(one.IsPositive(), "UShort constructor returns negative for positive one");
            Assert.IsTrue(one.Len() == 1, "UShort constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(one);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 1, "UShort constructor returns different than positive one");
        }

        [TestMethod]
        public void TestUshortConstructorMaxValue()
        {
            AnySizeInteger maxvalue = new AnySizeInteger(ushort.MaxValue);
            Assert.IsTrue(maxvalue.IsPositive(), "UShort constructor returns negative for positive value");
            Assert.IsTrue(maxvalue.Len() == 1, "UShort constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(maxvalue);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == (uint)ushort.MaxValue, "UShort constructor returns different than positive MaxValue");
        }
        #endregion

        #region Byte constructors
        [TestMethod]
        public void TestByteConstructorZero()
        {
            byte z = 0;
            AnySizeInteger zero = new AnySizeInteger(z);
            Assert.IsTrue(zero.IsPositive(), "Byte constructor returns negative for zero");
            Assert.IsTrue(zero.Len() == 1, "Byte constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(zero);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 0, "Byte constructor returns different than zero");
        }

        [TestMethod]
        public void TestByteConstructorOne()
        {
            ushort o = 1;
            AnySizeInteger one = new AnySizeInteger(o);
            Assert.IsTrue(one.IsPositive(), "Byte constructor returns negative for positive one");
            Assert.IsTrue(one.Len() == 1, "Byte constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(one);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 1, "Byte constructor returns different than positive one");
        }

        [TestMethod]
        public void TestByteConstructorMaxValue()
        {
            AnySizeInteger maxvalue = new AnySizeInteger(byte.MaxValue);
            Assert.IsTrue(maxvalue.IsPositive(), "Byte constructor returns negative for positive value");
            Assert.IsTrue(maxvalue.Len() == 1, "Byte constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(maxvalue);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == (uint)byte.MaxValue, "UShort constructor returns different than positive MaxValue");
        }
        #endregion

        #region Long constructors
        [TestMethod]
        public void TestLongConstructorZero()
        {
            AnySizeInteger zero = new AnySizeInteger(0L);
            Assert.IsTrue(zero.IsPositive(), "Long constructor returns negative for zero");
            Assert.IsTrue(zero.Len() == 1, "Long constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(zero);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 0, "Long constructor returns different than zero");
        }

        [TestMethod]
        public void TestLongConstructorOne()
        {
            AnySizeInteger one = new AnySizeInteger(1L);
            Assert.IsTrue(one.IsPositive(), "Long constructor returns negative for positive one");
            Assert.IsTrue(one.Len() == 1, "Long constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(one);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 1, "Long constructor returns different than positive one");
        }

        [TestMethod]
        public void TestLongConstructorMinusOne()
        {
            AnySizeInteger minusone = new AnySizeInteger(-1L);
            Assert.IsTrue(minusone.IsNegative(), "Long constructor returns positive for negative one");
            Assert.IsTrue(minusone.Len() == 1, "Long constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(minusone);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 1, "Long constructor returns different than positive one");
        }

        [TestMethod]
        public void TestLongConstructorMaxValue()
        {
            AnySizeInteger maxvalue = new AnySizeInteger(long.MaxValue);
            Assert.IsTrue(maxvalue.IsPositive(), "Long constructor returns negative for positive value");
            Assert.IsTrue(maxvalue.Len() == 2, "Long constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(maxvalue);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 2, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == uint.MaxValue && digitsValue[1] == int.MaxValue, "Long constructor returns different than positive MaxValue");
        }

        [TestMethod]
        public void TestLongConstructorMinValue()
        {
            AnySizeInteger minvalue = new AnySizeInteger(long.MinValue);
            Assert.IsTrue(minvalue.IsNegative(), "Int constructor returns positive for negative value");
            Assert.IsTrue(minvalue.Len() == 3, "Int constructor Len different than 2");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(minvalue);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 3, "Digits size different than 2");
            Assert.IsTrue(digitsValue[0] == 0 && digitsValue[1] == 0 && digitsValue[2] == 1, "Int constructor returns different than positive MinValue");
        }
        #endregion

        #region Ulong constructors
        [TestMethod]
        public void TestULongConstructorZero()
        {
            ulong z = 0UL;
            AnySizeInteger zero = new AnySizeInteger(z);
            Assert.IsTrue(zero.IsPositive(), "ULong constructor returns negative for zero");
            Assert.IsTrue(zero.Len() == 1, "ULong constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(zero);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 0U, "ULong constructor returns different than zero");
        }

        [TestMethod]
        public void TestUlongConstructorOne()
        {
            ulong o = 1UL;
            AnySizeInteger one = new AnySizeInteger(o);
            Assert.IsTrue(one.IsPositive(), "ULong constructor returns negative for positive one");
            Assert.IsTrue(one.Len() == 1, "ULong constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(one);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 1, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == 1, "ULong constructor returns different than positive one");
        }

        [TestMethod]
        public void TestUlongConstructorMaxValue()
        {
            AnySizeInteger maxvalue = new AnySizeInteger(ulong.MaxValue);
            Assert.IsTrue(maxvalue.IsPositive(), "ULong constructor returns negative for positive value");
            Assert.IsTrue(maxvalue.Len() == 2, "ULong constructor Len different than 1");

            Type anysizeintegerType = typeof(AnySizeInteger);
            FieldInfo digitsInfo = anysizeintegerType.GetField("digits", BindingFlags.NonPublic | BindingFlags.Instance);
            ulong[] digitsValue = (ulong[])digitsInfo.GetValue(maxvalue);

            Assert.IsNotNull(digitsValue, "Reflection couldn't get digits");
            Assert.IsTrue(digitsValue.Length == 2, "Digits size different than 1");
            Assert.IsTrue(digitsValue[0] == uint.MaxValue && digitsValue[1] == uint.MaxValue, "ULong constructor returns different than positive MaxValue");
        }
        #endregion
    }
}
