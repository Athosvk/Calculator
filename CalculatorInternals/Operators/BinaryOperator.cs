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

        public override bool Equals(object a_Other)
        {
            if (a_Other is BinaryOperator otherOperator)
            {
                // Regardless of their operands, different operators are never equal
                if (a_Other.GetType() != GetType())
                {
                    return false;
                }
                return otherOperator.m_FirstOperand.Equals(m_FirstOperand)
                    && otherOperator.m_SecondOperand.Equals(m_SecondOperand);
            }
            return base.Equals(a_Other);
        }

        protected IExpression m_FirstOperand;
        protected IExpression m_SecondOperand;
    }
}
