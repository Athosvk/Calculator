using System;
using System.Collections.Generic;

namespace CalculatorInternals
{
    /// <summary>
    /// Builds a value from a sequence of digits, with possibly a separator in between
    /// </summary>
    public class ValueBuilder
    {
        /// <summary>
        /// Gets the value that was built from the pushed digits and, if applicable, separator
        /// </summary>
        /// <returns>The built value</returns>
        public decimal GetValue()
        {
            if (m_Digits.Count == 0)
            {
                throw new InvalidOperationException("Must build from at least one value");
            }

            decimal value = 0M;
            
            decimal multiplier = GetDecimalMultiplier();
            for (int i = m_Digits.Count - 1; i >= 0; i--)
            {
                value += m_Digits[i] * multiplier;
                multiplier *= 10;
            }
            return value;
        }

        private decimal GetDecimalMultiplier()
        {
            if (!m_SeparatorPushed)
            {
                return 1;
            }

            // The resulting number is divided by 10 for each digit that
            // goes after the separator. The separator position points to the
            // first digit in m_Digits that goes after the separator, meaning
            // we have to subtract it from the total amount of digits
            return 1 / (decimal)Math.Pow(10, m_Digits.Count - m_SeparatorPosition - 1);
        }

        /// <summary>
        /// Pushes the digit to the current value
        /// </summary>
        /// <param name="a_Digit">The digit to add to the value being built</param>
        public void PushDigit(byte a_Digit)
        {
            m_Digits.Add(a_Digit);
        }

        /// <summary>
        /// Pushes a (dot) separator for a decimal value. Every subsequently pushed digit
        /// will go after the decimal separator
        /// </summary>
        public void PushSeparator()
        {
            if (m_SeparatorPushed)
            {
                throw new InvalidOperationException("Already has a separator");
            }
            m_SeparatorPosition = m_Digits.Count - 1;
            m_SeparatorPushed = true;
        }

        /// <summary>
        /// Clears the currently built value (i.e. resets it to 0.0)
        /// </summary>
        public void Clear()
        {
            m_Digits.Clear();
            m_SeparatorPushed = false;
            m_SeparatorPosition = -1;
        }

        List<byte> m_Digits = new List<byte>();
        int m_SeparatorPosition = -1;
        bool m_SeparatorPushed = false;
    }
}
