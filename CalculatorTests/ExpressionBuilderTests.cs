using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorInternals;
using System;
using System.Collections.Generic;

namespace CalculatorTests
{
    [TestClass]
    public class ExpressionBuilderTests
    {
        [TestMethod]
        public void TestSingleValue()
        {
            ExpressionBuilder expressionBuilder = new ExpressionBuilder();

            Value value = (Value)3;
            expressionBuilder.PushValue(value);
            Assert.IsTrue(expressionBuilder.GenerateExpression() is Value);
            Assert.AreEqual(value, (Value)expressionBuilder.GenerateExpression());
        }

        [TestMethod]
        public void TestSingleOperator()
        {
            ExpressionBuilder expressionBuilder = new ExpressionBuilder();
            expressionBuilder.PushValue((Value)5);
            expressionBuilder.PushOperator<AddOperator>();
            expressionBuilder.PushValue((Value)4);

            AddOperator addOperation = new AddOperator();
            addOperation.SetFirstOperand((Value)5);
            addOperation.SetSecondOperand((Value)4);
            Assert.AreEqual(addOperation, expressionBuilder.GenerateExpression());
        }

        [TestMethod]
        public void TestSuccessiveOperators()
        {
            ExpressionBuilder expressionBuilder = new ExpressionBuilder();
            expressionBuilder.PushValue((Value)5);
            expressionBuilder.PushOperator<AddOperator>();
            expressionBuilder.PushValue((Value)4);
            expressionBuilder.PushOperator<AddOperator>();
            expressionBuilder.PushValue((Value)4);

            AddOperator nestedAddOperation = new AddOperator();
            nestedAddOperation.SetFirstOperand((Value)5);
            nestedAddOperation.SetSecondOperand((Value)4);

            AddOperator addOperation = new AddOperator();
            addOperation.SetFirstOperand(nestedAddOperation);
            addOperation.SetSecondOperand((Value)4);
            Assert.AreEqual(addOperation, expressionBuilder.GenerateExpression());
        }
    }
}
