﻿using System.Text;

namespace CalculatorInternals
{
    /// <summary>
    /// Represents a multiplication operation
    /// </summary>
    public class MultiplicationOperator : BinaryOperator
    {
        /// <summary>
        /// Evaluates (folds) the expression to a single value, evaluating all its operands
        /// </summary>
        /// <returns>The result of the expression</returns>
        public override decimal Evaluate()
        {
            return m_FirstOperand.Evaluate() * m_SecondOperand.Evaluate();
        }

        /// <summary>
        /// Converts the multiplication expression to a string representation
        /// </summary>
        /// <returns>The stringified representation of the multiplication expression</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(m_FirstOperand.ToString() + " × ");
            if (m_SecondOperand != null)
            {
                stringBuilder.Append(m_SecondOperand.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
