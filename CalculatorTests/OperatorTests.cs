using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorInternals;

namespace CalculatorTests
{
    [TestClass]
    public class OperatorTests
    {
        [TestMethod]
        public void TestAddition()
        {
            AddOperator addExpression = new AddOperator();
            addExpression.SetFirstOperand(new Value(1.5M));
            addExpression.SetSecondOperand(new Value(1.5M));
            Assert.AreEqual(3.0M, addExpression.Evaluate());
        }

        [TestMethod]
        public void TestSubtraction()
        {
            SubtractionOperator subtractionExpression = new SubtractionOperator();
            subtractionExpression.SetFirstOperand(new Value(2.17M));
            subtractionExpression.SetSecondOperand(new Value(2.07M));
            Assert.AreEqual(0.1M, subtractionExpression.Evaluate());
       }

        [TestMethod]
        public void TestMultiplication()
        {
            MultiplicationOperator multiplicationExpression = new MultiplicationOperator();
            multiplicationExpression.SetFirstOperand(new Value(1.1M));
            multiplicationExpression.SetSecondOperand(new Value(2M));
            Assert.AreEqual(2.2M, multiplicationExpression.Evaluate());
       }
    }
}
