using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorInternals
{
    /// <summary>
    /// Builds an expression from successively entered expressions
    /// </summary>
    public class ExpressionBuilder
    {
        /// <summary>
        /// Pushes a value into the expression, based upon the previous input
        /// </summary>
        /// <param name="a_Value">The value to add to the expression</param>
        public void PushValue(Value a_Value)
        {
            m_ExpressionComponents.Add(a_Value);
        }

        /// <summary>
        /// Pushes an operator of type T into the expression
        /// </summary>
        /// <typeparam name="T">The type of the operator to add</typeparam>
        public void PushOperator<T>() where T : BinaryOperator, new()
        {
            T binaryOperator = new T();
            m_ExpressionComponents.Add(binaryOperator);
        }

        /// <summary>
        /// Generates the expression from the set of pushed values and operators
        /// </summary>
        public IExpression GenerateExpression()
        {
            if (m_ExpressionComponents.Count == 1)
            {
                return m_ExpressionComponents[0];
            }

            BinaryOperator previousOperator = (BinaryOperator)m_ExpressionComponents[1];
            previousOperator.SetFirstOperand(m_ExpressionComponents[0]);
            previousOperator.SetSecondOperand(m_ExpressionComponents[2]);
            for (int i = 3; i < m_ExpressionComponents.Count; i += 2)
            {
                BinaryOperator binaryOperation = (m_ExpressionComponents[i] as BinaryOperator);
                binaryOperation.SetFirstOperand(previousOperator);
                binaryOperation.SetSecondOperand(m_ExpressionComponents[i + 1]);
                previousOperator = binaryOperation;
            }
            return previousOperator;
        }

        private List<IExpression> m_ExpressionComponents = new List<IExpression>();
    }
}
