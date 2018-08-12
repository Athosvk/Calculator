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

            decimal value = 0.0M;
            int multiplier = 1;
            for (int i = m_Digits.Count - 1; i >= 0; i--)
            {
                value += m_Digits[i] * multiplier;
                multiplier *= 10;
            }
            return value;
        }

        /// <summary>
        /// Pushes the digit to the current value
        /// </summary>
        /// <param name="a_Digit">The digit to add to the value being built</param>
        public void PushDigit(byte a_Digit)
        {
            m_Digits.Add(a_Digit);
        }

        List<byte> m_Digits = new List<byte>();
    }
}
