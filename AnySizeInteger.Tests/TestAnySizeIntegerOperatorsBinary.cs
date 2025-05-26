using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnySizeIntegerUnitTestSuite
{
    using System.Reflection;
    using Katedra;

    [TestClass]
    public class TestAnySizeIntegerOperatorsBinary
    {
        #region Equality ==
        [TestMethod]
        public void TestEqualityWithSameOne()
        {
            AnySizeInteger one = new AnySizeInteger(1);
            Assert.IsTrue(one == one, "'EqualityWithSame' test failed");

            AnySizeInteger uno = one;
            Assert.IsTrue(one == uno, "'EqualityWithSame' test failed");
        }

        [TestMethod]
        public void TestEqualityWithEquivalentOne()
        {
            AnySizeInteger one = new AnySizeInteger(1);
            AnySizeInteger uno = new AnySizeInteger(1);
            Assert.IsTrue(one == uno, "'EqualityWithEquivalent' test failed");
        }

        [TestMethod]
        public void TestEqualityWithNull()
        {
            AnySizeInteger one = new AnySizeInteger(1);
            AnySizeInteger nil = null;
            Assert.IsFalse(one == nil, "'EqualityWithNull' test failed");
        }

        [TestMethod]
        public void TestEqualityAllNull()
        {
            AnySizeInteger a = null;
            AnySizeInteger b = null;
            Assert.IsFalse(a == b, "'EqualityAllNull' test failed");
        }

        [TestMethod]
        public void TestEqualityWithEquivalent9876543210()
        {

            ConstructorInfo constructor = typeof(AnySizeInteger).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance, 
                null, 
                new Type[] { typeof(uint[]), typeof(bool) }, 
                null);

            object[] parameters = new object[2];
            parameters[0] = new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            parameters[1] = false;
            AnySizeInteger a = (AnySizeInteger)constructor.Invoke(parameters);
            AnySizeInteger b = (AnySizeInteger)constructor.Invoke(parameters);

            Assert.IsTrue(a == b, "'EqualityWithEquivalent9876543210' test failed");
        }

        [TestMethod]
        public void TestEqualityWithDifferent()
        {

            ConstructorInfo constructor = typeof(AnySizeInteger).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new Type[] { typeof(uint[]), typeof(bool) },
                null);

            object[] parameters = new object[2];
            parameters[0] = new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            parameters[1] = false;
            AnySizeInteger a = (AnySizeInteger)constructor.Invoke(parameters);
            parameters[1] = true;
            AnySizeInteger b = (AnySizeInteger)constructor.Invoke(parameters);

            Assert.IsFalse(a == b, "'EqualityWithSignDifference9876543210' test failed");

            a = new AnySizeInteger(0);
            b = new AnySizeInteger(1);
            Assert.IsFalse(a == b, "'EqualityWithZeroVsOne' test failed");

            b = null;
            Assert.IsFalse(a == b, "'EqualityWithZeroVsNull' test failed");
        }
        #endregion

        #region Inequality !=
        [TestMethod]
        public void TestInequalityWithSameOne()
        {
            AnySizeInteger one = new AnySizeInteger(1);
            Assert.IsFalse(one != one, "'InequalityWithSame' test failed");

            AnySizeInteger uno = one;
            Assert.IsFalse(one != uno, "'InequalityWithSame' test failed");
        }

        [TestMethod]
        public void TestInequalityWithEquivalentOne()
        {
            AnySizeInteger one = new AnySizeInteger(1);
            AnySizeInteger uno = new AnySizeInteger(1);
            Assert.IsFalse(one != uno, "'InequalityWithEquivalent' test failed");
        }

        [TestMethod]
        public void TestInequalityWithNull()
        {
            AnySizeInteger one = new AnySizeInteger(1);
            AnySizeInteger nil = null;
            Assert.IsTrue(one != nil, "'InequalityWithNull' test failed");
        }

        [TestMethod]
        public void TestInequalityAllNull()
        {
            AnySizeInteger a = null;
            AnySizeInteger b = null;
            Assert.IsTrue(a != b, "'InequalityAllNull' test failed");
        }

        [TestMethod]
        public void TestInequalityWithEquivalent9876543210()
        {

            ConstructorInfo constructor = typeof(AnySizeInteger).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new Type[] { typeof(uint[]), typeof(bool) },
                null);

            object[] parameters = new object[2];
            parameters[0] = new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            parameters[1] = false;
            AnySizeInteger a = (AnySizeInteger)constructor.Invoke(parameters);
            AnySizeInteger b = (AnySizeInteger)constructor.Invoke(parameters);

            Assert.IsFalse(a != b, "'InequalityWithEquivalent9876543210' test failed");
        }

        [TestMethod]
        public void TestInequalityWithDifferent()
        {

            ConstructorInfo constructor = typeof(AnySizeInteger).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new Type[] { typeof(uint[]), typeof(bool) },
                null);

            object[] parameters = new object[2];
            parameters[0] = new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            parameters[1] = false;
            AnySizeInteger a = (AnySizeInteger)constructor.Invoke(parameters);
            parameters[1] = true;
            AnySizeInteger b = (AnySizeInteger)constructor.Invoke(parameters);

            Assert.IsTrue(a != b, "'InequalityWithSignDifference9876543210' test failed");
        }

        #endregion

        #region LessThan <
        [TestMethod]
        public void TestLessThanBothPositive()
        {
            throw new NotImplementedException(nameof(TestLessThanBothPositive));
        }

        [TestMethod]
        public void TestLessThanBothNegative()
        {
            throw new NotImplementedException(nameof(TestLessThanBothNegative));
        }

        [TestMethod]
        public void TestLessThanComparedWithZero()
        {
            throw new NotImplementedException(nameof(TestLessThanComparedWithZero));
        }

        [TestMethod]
        public void TestLessThanPositiveNegative()
        {
            throw new NotImplementedException(nameof(TestLessThanPositiveNegative));
        }

        [TestMethod]
        public void TestLessThanWithSameOne()
        {
            throw new NotImplementedException(nameof(TestLessThanWithSameOne));
        }
        #endregion

        #region GreaterThan >
        [TestMethod]
        public void TestGreaterThanBothPositive()
        {
            throw new NotImplementedException(nameof(TestGreaterThanBothPositive));
        }

        [TestMethod]
        public void TestGreaterThanBothNegative()
        {
            throw new NotImplementedException(nameof(TestGreaterThanBothNegative));
        }

        [TestMethod]
        public void TestGreaterThanComparedWithZero()
        {
            throw new NotImplementedException(nameof(TestGreaterThanComparedWithZero));
        }

        [TestMethod]
        public void TestGreaterThanPositiveNegative()
        {
            throw new NotImplementedException(nameof(TestGreaterThanPositiveNegative));
        }

        [TestMethod]
        public void TestGreaterThanWithSameOne()
        {
            throw new NotImplementedException(nameof(TestGreaterThanWithSameOne));
        }
        #endregion

        #region Add +
        #endregion

        #region Subtract -
        #endregion

        #region Product *
        #endregion

        #region Division /
        #endregion
    }
}
