namespace CalculatorInternals
{
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