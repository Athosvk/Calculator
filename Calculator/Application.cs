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
            OnValueButtonClicked(0);
        }

        private void Value1Button_Click(object sender, EventArgs e)
        {
            OnValueButtonClicked(1);
        }

        private void Value2Button_Click(object sender, EventArgs e)
        {
            OnValueButtonClicked(2);
        }

        private void Value3Button_CLick(object sender, EventArgs e)
        {
            OnValueButtonClicked(3);
        }

        private void Value4Button_Click(object sender, EventArgs e)
        {
            OnValueButtonClicked(4);
        }

        private void Value5Button_Click(object sender, EventArgs e)
        {
            OnValueButtonClicked(5);
        }

        private void Value6Button_Click(object sender, EventArgs e)
        {
            OnValueButtonClicked(6);
        }

        private void Value7Button_Click(object sender, EventArgs e)
        {
            OnValueButtonClicked(7);
        }

        private void Value8Button_Click(object sender, EventArgs e)
        {
            OnValueButtonClicked(8);
        }

        private void Value9Button_Click(object sender, EventArgs e)
        {
            OnValueButtonClicked(9);
        }

        private void OnValueButtonClicked(int inValue)
        {
            if (m_FirstValue != null && m_AddPressed)
            {
                (m_CurrentExpression as BinaryOperator).SetSecondOperand(new Value(inValue));
            }
            else
            {
                m_FirstValue = new Value(inValue);
            }
        }

        private void ResultButton_Click(object sender, EventArgs e)
        {
            if (m_CurrentExpression != null)
            {
                Display.Text = m_CurrentExpression.Evaluate().ToString();
            }
            else if (m_FirstValue != null)
            {
                Display.Text = m_FirstValue.Evaluate().ToString();
            }
            else
            {
                Display.Text = "Nothing was entered";
            }
            m_FirstValue = null;
            m_CurrentExpression = null;
            m_AddPressed = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            m_AddPressed = true;
            AddOperator addOperation = new AddOperator();
            addOperation.SetFirstOperand(m_FirstValue);
            m_CurrentExpression = addOperation;
        }

        private void SubtractButton_Click(object sender, EventArgs e)
        {
            m_AddPressed = true;
            SubtractionOperator subtractOperation = new SubtractionOperator();
            subtractOperation.SetFirstOperand(m_FirstValue);
            m_CurrentExpression = subtractOperation;
        }

        private IExpression m_FirstValue;
        private bool m_AddPressed;
        private IExpression m_CurrentExpression;
    }
}
