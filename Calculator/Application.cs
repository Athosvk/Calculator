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
            m_CurrentExpression = new Value(m_ValueBuilder.GetValue());
            RefreshResult();
        }

        private void ResultButton_Click(object sender, EventArgs e)
        {
            if (m_CurrentExpression != null)
            {
                Display.Text = m_CurrentExpression.ToString() + " = " + m_CurrentExpression.Evaluate().ToString();
            }
            else
            {
                Display.Text = "Nothing was entered";
            }
            m_CurrentExpression = null;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddOperator addOperation = new AddOperator();
            addOperation.SetFirstOperand(m_CurrentExpression);
            m_CurrentExpression = addOperation;
            RefreshResult();
        }

        private void SubtractButton_Click(object sender, EventArgs e)
        {
            SubtractionOperator subtractOperation = new SubtractionOperator();
            subtractOperation.SetFirstOperand(m_CurrentExpression);
            m_CurrentExpression = subtractOperation;
            RefreshResult();
        }

        private void RefreshResult()
        {
            Display.Text = m_CurrentExpression.ToString();
        }

        private ValueBuilder m_ValueBuilder = new ValueBuilder();
        private IExpression m_CurrentExpression;
    }
}
