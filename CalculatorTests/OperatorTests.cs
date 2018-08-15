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
            BinaryOperator addExpression = new AddOperator();
            addExpression.SetFirstOperand(new Value(1.5M));
            addExpression.SetSecondOperand(new Value(1.5M));
            Assert.AreEqual(3.0M, addExpression.Evaluate());
        }

        [TestMethod]
        public void TestSubtraction()
        {
            BinaryOperator subtractionExpression = new SubtractionOperator();
            subtractionExpression.SetFirstOperand(new Value(2.17M));
            subtractionExpression.SetSecondOperand(new Value(2.07M));
            Assert.AreEqual(0.1M, subtractionExpression.Evaluate());
        }

        [TestMethod]
        public void TestMultiplication()
        {
            BinaryOperator multiplicationExpression = new MultiplicationOperator();
            multiplicationExpression.SetFirstOperand(new Value(1.1M));
            multiplicationExpression.SetSecondOperand(new Value(2M));
            Assert.AreEqual(2.2M, multiplicationExpression.Evaluate());
        }

        [TestMethod]
        public void TestDivision()
        {
            BinaryOperator divisionExpression = new DivisionOperator();
            divisionExpression.SetFirstOperand(new Value(2.2M));
            divisionExpression.SetSecondOperand(new Value(1.1M));
            Assert.AreEqual(2M, divisionExpression.Evaluate());
        }

        [TestMethod]
        public void TestOperatorEquality()
        {
            BinaryOperator addOperation = new AddOperator();
            addOperation.SetFirstOperand((Value)5);
            addOperation.SetSecondOperand((Value)6);

            BinaryOperator addOperation2 = new AddOperator();
            addOperation2.SetFirstOperand((Value)5);
            addOperation2.SetSecondOperand((Value)6);
            Assert.AreEqual(addOperation, addOperation2);
        }

        [TestMethod]
        public void TestOperatorInequality()
        {
            BinaryOperator addOperation = new AddOperator();
            addOperation.SetFirstOperand((Value)5);
            addOperation.SetSecondOperand((Value)6);

            BinaryOperator addOperation2 = new AddOperator();
            addOperation2.SetFirstOperand((Value)4);
            addOperation2.SetSecondOperand((Value)6);
            Assert.AreNotEqual(addOperation, addOperation2);
        }

        [TestMethod]
        public void TestOperatorMismatchInequality()
        {
            BinaryOperator addOperation = new AddOperator();
            addOperation.SetFirstOperand((Value)5);
            addOperation.SetSecondOperand((Value)6);

            BinaryOperator divideOperation = new DivisionOperator();
            divideOperation.SetFirstOperand((Value)5);
            divideOperation.SetSecondOperand((Value)6);
            Assert.AreNotEqual(addOperation, divideOperation);
        }
    }
}
