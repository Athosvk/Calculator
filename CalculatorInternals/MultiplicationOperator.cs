using System.Text;

namespace CalculatorInternals
{
    /// <summary>
    /// Represents a multiplication operation
    /// </summary>
    public class MultiplicationOperator : BinaryOperator
    {
        public override decimal Evaluate()
        {
            return m_FirstOperand.Evaluate() * m_SecondOperand.Evaluate();
        }

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
