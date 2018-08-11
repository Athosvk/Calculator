namespace CalculatorInternals
{
    public static class Operations
    {
        public static int Add(int a_First, int a_Second)
        {
            return a_First + a_Second;
        }

        public static decimal Add(decimal a_First, decimal a_Second)
        {
            return a_First + a_Second;
        }

        public static int Subtract(int a_SubtractedFrom, int a_ToSubtract)
        {
            return a_SubtractedFrom - a_ToSubtract;
        }

        public static decimal Subtract(decimal a_First, decimal a_Second)
        {
            return a_First - a_Second;
        }
    }

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
    public class AddOperator : IExpression
    {
        /// <summary>
        /// Sets the first operand of this add expression
        /// </summary>
        /// <param name="a_Value">The value for the first operand</param>
        public void SetFirstOperand(IExpression a_Value)
        {
            m_FirstOperand = a_Value;
        }

        /// <summary>
        /// Sets the second operand of this add expression
        /// </summary>
        /// <param name="a_Value">The value for the second operand</param>
        public void SetSecondOperand(IExpression a_Value)
        {
            m_SecondOperand = a_Value;
        }

        /// <summary>
        /// Evaluates (folds) the expression to a single value, evaluating all its operands
        /// </summary>
        /// <returns>The result of the expression</returns>
        public decimal Evaluate()
        {
            return m_FirstOperand.Evaluate() + m_SecondOperand.Evaluate();
        }

        private IExpression m_FirstOperand;
        private IExpression m_SecondOperand;
    }
}