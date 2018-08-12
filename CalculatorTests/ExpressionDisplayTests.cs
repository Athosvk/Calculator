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
            BinaryOperator addOperation = new AddOperator();
            addOperation.SetFirstOperand(new Value(1.0M));
            addOperation.SetSecondOperand(new Value(1.0M));
            Assert.AreEqual("1.0 + 1.0".Replace(" ", ""), addOperation.ToString().Replace(" ", ""));
        }

        [TestMethod]
        public void TestPrintIncompleteAdd()
        {
            BinaryOperator addOperation = new AddOperator();
            addOperation.SetFirstOperand(new Value(1.0M));
            Assert.AreEqual("1.0 + ".Replace(" ", ""), addOperation.ToString().Replace(" ", ""));
        }

        [TestMethod]
        public void TestPrintSubtractionExpression()
        {
            BinaryOperator subtractOperation = new SubtractionOperator();
            subtractOperation.SetFirstOperand(new Value(2.9M));
            subtractOperation.SetSecondOperand(new Value(3.0M));
            Assert.AreEqual("2.9 - 3.0".Replace(" ", ""), subtractOperation.ToString().Replace(" ", ""));
        }

        /// <summary>
        /// Converts the value to a string representation
        /// </summary>
        /// <returns>The stringified representation</returns>
        [TestMethod]
        public void TestPrintIncompleteSubtract()
        {
            BinaryOperator subtractOperation = new SubtractionOperator();
            subtractOperation.SetFirstOperand(new Value(1.0M));
            Assert.AreEqual("1.0 - ".Replace(" ", ""), subtractOperation.ToString().Replace(" ", ""));
        }
    }
}
