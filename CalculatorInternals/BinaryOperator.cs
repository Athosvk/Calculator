namespace CalculatorInternals
{
    public abstract class BinaryOperator : IExpression
    {
        public abstract decimal Evaluate();

        public void SetFirstOperand(IExpression a_Value)
        {
            m_FirstOperand = a_Value;
        }

        public void SetSecondOperand(IExpression a_Value)
        {
            m_SecondOperand = a_Value;
        }

        protected IExpression m_FirstOperand;
        protected IExpression m_SecondOperand;
    }
}
