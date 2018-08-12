namespace CalculatorInternals
{
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

        /// <summary>
        /// Converts the value to a string representation
        /// </summary>
        /// <returns>The stringified representation</returns>
        public override string ToString()
        {
            return m_FirstOperand.ToString() + " + " + m_SecondOperand.ToString();
        }
    }
}
