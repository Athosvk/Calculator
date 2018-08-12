using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorInternals;

namespace Calculator
{
    public partial class Application : Form
    {
        public Application()
        {
            InitializeComponent();
        }

        private void Value0Button_Click(object sender, EventArgs e)
        {
            OnDigitPressed(0);
        }

        private void Value1Button_Click(object sender, EventArgs e)
        {
            OnDigitPressed(1);
        }

        private void Value2Button_Click(object sender, EventArgs e)
        {
            OnDigitPressed(2);
        }

        private void Value3Button_CLick(object sender, EventArgs e)
        {
            OnDigitPressed(3);
        }

        private void Value4Button_Click(object sender, EventArgs e)
        {
            OnDigitPressed(4);
        }

        private void Value5Button_Click(object sender, EventArgs e)
        {
            OnDigitPressed(5);
        }

        private void Value6Button_Click(object sender, EventArgs e)
        {
            OnDigitPressed(6);
        }

        private void Value7Button_Click(object sender, EventArgs e)
        {
            OnDigitPressed(7);
        }

        private void Value8Button_Click(object sender, EventArgs e)
        {
            OnDigitPressed(8);
        }

        private void Value9Button_Click(object sender, EventArgs e)
        {
            OnDigitPressed(9);
        }

        private void OnDigitPressed(byte inValue)
        {
            m_ValueBuilder.PushDigit(inValue);
            if (m_CurrentExpression == null || m_CurrentExpression is Value)
            {
                m_CurrentExpression = new Value(m_ValueBuilder.GetValue());
            }
            else
            {
                (m_CurrentExpression as BinaryOperator).SetSecondOperand(new Value(m_ValueBuilder.GetValue()));
            }
            RefreshResult();
        }

        private void ResultButton_Click(object sender, EventArgs e)
        {
            if (m_CurrentExpression != null)
            {
                Display.Text = m_CurrentExpression.ToString() + " = " + m_CurrentExpression.Evaluate().ToString("G29");
            }
            else
            {
                Display.Text = "Nothing was entered";
            }
            Clear();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            OnOperatorClick(new AddOperator());
        }

        private void SubtractButton_Click(object sender, EventArgs e)
        {
            OnOperatorClick(new SubtractionOperator());
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            OnOperatorClick(new MultiplicationOperator());
        }

        private void DivisionButton_Click(object sender, EventArgs e)
        {
            OnOperatorClick(new DivisionOperator());
        }

        /// <summary>
        /// Invoked when an operator has been clicked
        /// </summary>
        /// <param name="a_Operator">The operator the user intended to invoke</param>
        private void OnOperatorClick(BinaryOperator a_Operator)
        {
            a_Operator.SetFirstOperand(m_CurrentExpression);
            m_CurrentExpression = a_Operator;
            m_ValueBuilder.Clear();
            RefreshResult();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
            RefreshResult();
        }

        private void RefreshResult()
        {
            Display.Text = m_CurrentExpression != null ? m_CurrentExpression.ToString() : "";
        }
        
        private void Clear()
        {
            m_CurrentExpression = null;
            m_ValueBuilder.Clear();
        }

        private ValueBuilder m_ValueBuilder = new ValueBuilder();
        private IExpression m_CurrentExpression;
    }
}
