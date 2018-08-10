using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorInternals;

namespace CalculatorTests
{
    [TestClass]
    public class OperationTests
    {
        [TestMethod]
        public void TestAddition()
        {
            Assert.AreEqual(Operations.Add(1, 1), 2);
            Assert.AreEqual(Operations.Add(2.5M, 2.5M), 5.0M);
        }

        [TestMethod]
        public void TestSubtraction()
        {
            Assert.AreEqual(Operations.Subtract(2, 1), 1);
            Assert.AreEqual(Operations.Subtract(2.17M, 2.07M), 0.1M);
       }
    }
}
