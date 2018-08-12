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
            Assert.AreEqual("2", value.ToString());
        }

        [TestMethod]
        public void TestPrintAddExpression()
        {
            BinaryOperator addOperation = new AddOperator();
            addOperation.SetFirstOperand(new Value(1.0M));
            addOperation.SetSecondOperand(new Value(1.0M));
            Assert.AreEqual("1 + 1".Replace(" ", ""), addOperation.ToString().Replace(" ", ""));
        }

        [TestMethod]
        public void TestPrintIncompleteAdd()
        {
            BinaryOperator addOperation = new AddOperator();
            addOperation.SetFirstOperand(new Value(1.0M));
            Assert.AreEqual("1 + ".Replace(" ", ""), addOperation.ToString().Replace(" ", ""));
        }

        [TestMethod]
        public void TestPrintSubtractionExpression()
        {
            BinaryOperator subtractOperation = new SubtractionOperator();
            subtractOperation.SetFirstOperand(new Value(2.9M));
            subtractOperation.SetSecondOperand(new Value(3.0M));
            Assert.AreEqual("2.9 - 3".Replace(" ", ""), subtractOperation.ToString().Replace(" ", ""));
        }

        [TestMethod]
        public void TestPrintIncompleteSubtract()
        {
            BinaryOperator subtractOperation = new SubtractionOperator();
            subtractOperation.SetFirstOperand(new Value(1.0M));
            Assert.AreEqual("1 - ".Replace(" ", ""), subtractOperation.ToString().Replace(" ", ""));
        }

        [TestMethod]
        public void TestPrintMultiplicationExpression()
        {
            BinaryOperator multiplicationOperation = new MultiplicationOperator();
            multiplicationOperation.SetFirstOperand(new Value(2.9M));
            multiplicationOperation.SetSecondOperand(new Value(3.0M));
            Assert.AreEqual("2.9 × 3".Replace(" ", ""), multiplicationOperation.ToString().Replace(" ", ""));
        }

        [TestMethod]
        public void TestPrintIncompleteMultiply()
        {
            BinaryOperator multiplyOperation = new MultiplicationOperator();
            multiplyOperation.SetFirstOperand(new Value(1.0M));
            Assert.AreEqual("1 × ".Replace(" ", ""), multiplyOperation.ToString().Replace(" ", ""));
        }

        [TestMethod]
        public void TestPrintDivisionExpression()
        {
            BinaryOperator divisionOperation = new DivisionOperator();
            divisionOperation.SetFirstOperand(new Value(2.9M));
            divisionOperation.SetSecondOperand(new Value(3.0M));
            Assert.AreEqual("2.9 ÷ 3".Replace(" ", ""), divisionOperation.ToString().Replace(" ", ""));
        }

        [TestMethod]
        public void TestPrintIncompleteDivide()
        {
            BinaryOperator multiplyOperation = new DivisionOperator();
            multiplyOperation.SetFirstOperand(new Value(1.0M));
            Assert.AreEqual("1 ÷ ".Replace(" ", ""), multiplyOperation.ToString().Replace(" ", ""));
        }
    }
}
