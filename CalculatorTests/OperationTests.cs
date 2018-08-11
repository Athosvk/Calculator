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
            AddOperator addExpression = new AddOperator();
            addExpression.SetFirstOperand(new Value(1.5M));
            addExpression.SetSecondOperand(new Value(1.5M));
            Assert.AreEqual(addExpression.Evaluate(), 3.0M);
        }

        [TestMethod]
        public void TestSubtraction()
        {
            Assert.AreEqual(Operations.Subtract(2, 1), 1);
            Assert.AreEqual(Operations.Subtract(2.17M, 2.07M), 0.1M);
       }
    }
}
