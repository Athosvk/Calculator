namespace CalculatorInternals
{
    /// <summary>
    /// Represents a single value in a (sub)-expression
    /// </summary>
    public struct Value : IExpression
    {
        /// <param name="a_Value">The value itself</param>
        public Value(decimal a_Value)
        {
            m_Value = a_Value;
        }

        /// <summary>
        /// Evaluates (folds) the expression to a single value, evaluating all its operands
        /// </summary>
        /// <returns>The result of the expression</returns>
        public decimal Evaluate()
        {
            return m_Value;
        }

        private decimal m_Value;
    }

    /// <summary>
    /// Represents an add operation
    /// </summary>
    public class AddOperator : BinaryOperator
    {
        /// <summary>
        /// Evaluates (folds) the expression to a single value, evaluating all its operands
        /// </summary>
        /// <returns>The result of the expression</returns>
        public override decimal Evaluate()
        {
            return m_FirstOperand.Evaluate() + m_SecondOperand.Evaluate();
        }
    }

    /// <summary>
    /// Represents an add operation
    /// </summary>
    public class SubtractionOperator : BinaryOperator
    {
        /// <summary>
        /// Evaluates (folds) the expression to a single value, evaluating all its operands
        /// </summary>
        /// <returns>The result of the expression</returns>
        public override decimal Evaluate()
        {
            return m_FirstOperand.Evaluate() - m_SecondOperand.Evaluate();
        }
    }
}