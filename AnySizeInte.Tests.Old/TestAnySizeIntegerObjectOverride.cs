using System.Reflection;
using AnySizeInt;

namespace AnySizeInt.Tests
{
    public class TestAnySizeIntegerObjectOverride
    {
        #region Equals
        [Fact]
        public void TestObjectOverrideEqualsWithSame()
        {
            AnySizeInteger one = new AnySizeInteger(1);
            object oneref = one;
            Assert.IsTrue(one.Equals(oneref), "'OverrideEqualsWithSame' test failed");
        }

        [Fact]
        public void TestObjectOverrideEqualsWithSameValue()
        {
            AnySizeInteger one = new AnySizeInteger(1);
            object oneref = one;
            AnySizeInteger uno = new AnySizeInteger(1);
            Assert.IsTrue(uno.Equals(oneref), "'OverrideEqualsWithSameValue' test failed");
        }

        [Fact]
        public void TestObjectOverrideEqualsWithNull()
        {
            AnySizeInteger one = new AnySizeInteger(1);
            object oneref = null;
            Assert.IsFalse(one.Equals(oneref), "'OverrideEqualsWithNull' test failed");
        }

        [Fact]
        public void TestObjectOverrideEqualsWithInt()
        {
            AnySizeInteger one = new AnySizeInteger(1);
            int uno = 1;
            Assert.IsFalse(one.Equals(uno), "'OverrideEqualsWithInt' test failed");
        }
        #endregion

        #region GetHashCode
        [Fact]
        public void TestGetHashCode()
        {

            ConstructorInfo constructor = typeof(AnySizeInteger).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new Type[] { typeof(uint[]), typeof(bool) },
                null);

            object[] parameters = new object[2];
            parameters[0] = new uint[] { 0, 1 };
            parameters[1] = false;
            AnySizeInteger a = (AnySizeInteger)constructor.Invoke(parameters);

            Assert.IsTrue(a.GetHashCode() == 1, "'GetHasCode 1' test failed");

            parameters[0] = new uint[] { 0, 1, 2 };
            a = (AnySizeInteger)constructor.Invoke(parameters);

            Assert.IsTrue(a.GetHashCode() == 3, "'GetHasCode 3' test failed");

            parameters[0] = new uint[] { 0, 1, 2, 3 };
            a = (AnySizeInteger)constructor.Invoke(parameters);

            Assert.IsTrue(a.GetHashCode() == 0, "'GetHasCode 3' test failed");

            parameters[0] = new uint[] { 0x55555555, 0xAAAAAAAA };
            a = (AnySizeInteger)constructor.Invoke(parameters);

            Assert.IsTrue(a.GetHashCode() == -1, "'GetHasCode -1' test failed");
        }
        #endregion

        #region ToString
        [Fact]
        public void TestObjectOverrideToStringZero()
        {
            AnySizeInteger zero = new AnySizeInteger(0);
            Assert.IsTrue(zero.ToString() == "0", "'OverrideToStringZero' test failed");
        }

        [Fact]
        public void TestObjectOverrideToStringOne()
        {
            AnySizeInteger one = new AnySizeInteger(1);
            Assert.IsTrue(one.ToString() == "1", "'OverrideToStringOne' test failed");
        }

        [Fact]
        public void TestObjectOverrideToStringMinusOne()
        {
            AnySizeInteger minusone = new AnySizeInteger(-1);
            Assert.IsTrue(minusone.ToString() == "- 1", "'OverrideToStringMinusOne' test failed");
        }

        [Fact]
        public void TestObjectOverrideToStringMaxUlong()
        {
            AnySizeInteger unintmaxvalue = new AnySizeInteger(UInt64.MaxValue);
            string expected = UInt32.MaxValue.ToString() + ":" + UInt32.MaxValue.ToString();
            Assert.IsTrue(unintmaxvalue.ToString() == expected, "'OverrideToStringMaxUlong' test failed");
        }

        [Fact]
        public void TestObjectOverrideToStringMinusMaxUlong()
        {
            AnySizeInteger unintmaxvalue = -(new AnySizeInteger(UInt64.MaxValue));
            string expected = "- " + UInt32.MaxValue.ToString() + ":" + UInt32.MaxValue.ToString();
            Assert.IsTrue(unintmaxvalue.ToString() == expected, "'OverrideToStringMaxUlong' test failed");
        }

        [Fact]
        public void TestObjectOverrideToStringLongNumber()
        {
            uint[] coefficients = new uint[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            bool sign = false;
            Object[] arguments = new Object[]{ coefficients, sign };
            Type anysizeintegerType = typeof(AnySizeInteger);

            var longnumber = new PrivateObject(anysizeintegerType, arguments);
            string expected = "9:8:7:6:5:4:3:2:1";
            Assert.IsTrue(longnumber.Invoke("ToString",null).ToString() == expected, "'OverrideToStringLongNumber' test failed");
        }

        [Fact]
        public void TestObjectOverrideToStringMinusLongNumber()
        {
            uint[] coefficients = new uint[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            bool sign = true;
            Object[] arguments = new Object[] { coefficients, sign };
            Type anysizeintegerType = typeof(AnySizeInteger);

            var longnumber = new PrivateObject(anysizeintegerType, arguments);
            string expected = "- 9:8:7:6:5:4:3:2:1";
            Assert.IsTrue(longnumber.Invoke("ToString", null).ToString() == expected, "'OverrideToStringMinusLongNumber' test failed");
        }
        #endregion
    }
}
