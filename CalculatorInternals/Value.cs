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

        /// <summary>
        /// Converts the value to a string representation
        /// </summary>
        /// <returns>The stringified value</returns>
        public override string ToString()
        {
            // 'G' specifier specifies precision, which has a max of 29 digits
            // for decimals anyway
            return m_Value.ToString();
        }

        private decimal m_Value;
    }
}
