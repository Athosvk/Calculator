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
        public void TestAfterClear()
        {
            ValueBuilder builder = new ValueBuilder();
            builder.PushDigit(1);

            builder.Clear();

            builder.PushDigit(2);
            Assert.AreEqual(2, builder.GetValue());
        }

        [TestMethod]
        public void TestSingleDigitDecimal()
        {
            ValueBuilder builder = new ValueBuilder();
            builder.PushDigit(1);
            builder.PushSeparator();
            builder.PushDigit(2);
            Assert.AreEqual(1.2M, builder.GetValue());
        }

        [TestMethod]
        public void TestMultiDigitDecimal()
        {
            ValueBuilder builder = new ValueBuilder();
            builder.PushDigit(1);
            builder.PushDigit(2);
            builder.PushSeparator();
            builder.PushDigit(3);
            builder.PushDigit(4);
            Assert.AreEqual(12.34M, builder.GetValue());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
            "It should not be valid to have multiple separators")]
        public void TestDoubleSeparator()
        {
            ValueBuilder builder = new ValueBuilder();
            builder.PushSeparator();
            builder.PushDigit(5);
            builder.PushSeparator();
        }

        [TestMethod]
        public void TestLeadingSeparator()
        {
            ValueBuilder builder = new ValueBuilder();
            builder.PushSeparator();
            builder.PushDigit(1);
            builder.PushDigit(4);
            Assert.AreEqual(0.14M, builder.GetValue());
        }
    }
}
