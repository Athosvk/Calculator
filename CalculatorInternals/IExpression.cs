using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorInternals
{
    /// <summary>
    /// Represents an expression that can be evaluated to a value
    /// </summary>
    public interface IExpression
    {
        /// <summary>
        /// Evaluates (folds) the expression to a single value, evaluating all its operands
        /// </summary>
        /// <returns>The result of the expression</returns>
        decimal Evaluate();
    }
}
