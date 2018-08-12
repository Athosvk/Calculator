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
            SubtractionOperator subtractionExpression = new SubtractionOperator();
            subtractionExpression.SetFirstOperand(new Value(2.17M));
            subtractionExpression.SetSecondOperand(new Value(2.07M));
            Assert.AreEqual(subtractionExpression.Evaluate(), 0.1M);
       }
    }
}
