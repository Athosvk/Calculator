using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorInternals;

namespace CalculatorTests
{
    [TestClass]
    public class ExpressionDisplayTests
    {
        [TestMethod]
        public void TestPrintValue()
        {
            Value value = new Value(2.0M);
            Assert.AreEqual("2.0", value.ToString());
        }

        [TestMethod]
        public void TestPrintAddExpression()
        {
            AddOperator addOperation = new AddOperator();
            addOperation.SetFirstOperand(new Value(1.0M));
            addOperation.SetSecondOperand(new Value(1.0M));
            Assert.AreEqual("1.0 + 1.0".Replace(" ", ""), addOperation.ToString().Replace(" ", ""));
        }

        [TestMethod]
        public void TestPrintIncompleteAdd()
        {
            AddOperator addOperation = new AddOperator();
            addOperation.SetFirstOperand(new Value(1.0M));
            Assert.AreEqual("1.0 + ".Replace(" ", ""), addOperation.ToString().Replace(" ", ""));
        }
    }
}
