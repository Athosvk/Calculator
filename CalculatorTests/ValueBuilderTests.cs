using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalculatorInternals;

namespace CalculatorTests
{
    [TestClass]
    public class ValueBuilderTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A ValueBuilder " +
            "should require at least one digit to build from")]
        public void TestEmptyValue()
        {
            ValueBuilder builder = new ValueBuilder();
            builder.GetValue();
        }

        [TestMethod]
        public void TestSingleDigit()
        {
            ValueBuilder builder = new ValueBuilder();
            builder.PushDigit(1);
            Assert.AreEqual(1, builder.GetValue());
        }

        [TestMethod]
        public void TestBuildMultipleDigits()
        {
            ValueBuilder builder = new ValueBuilder();
            builder.PushDigit(1);
            builder.PushDigit(3);
            Assert.AreEqual(13, builder.GetValue());
        }

        [TestMethod]
        public void TestEmptyAfterClear()
        {
            ValueBuilder builder = new ValueBuilder();
        }
    }
}
