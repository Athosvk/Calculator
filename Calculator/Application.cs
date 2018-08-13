using System;
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
            Confirm();
        }

        private void Confirm()
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
            OnOperatorPressed(new AddOperator());
        }

        private void SubtractButton_Click(object sender, EventArgs e)
        {
            OnOperatorPressed(new SubtractionOperator());
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            OnOperatorPressed(new MultiplicationOperator());
        }

        private void DivisionButton_Click(object sender, EventArgs e)
        {
            OnOperatorPressed(new DivisionOperator());
        }

        /// <summary>
        /// Invoked when an operator has been clicked
        /// </summary>
        /// <param name="a_Operator">The operator the user intended to invoke</param>
        private void OnOperatorPressed(BinaryOperator a_Operator)
        {
            if (m_CurrentExpression == null)
            {
                // Early out as there is no initial value yet
                return;
            }
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

        private void Application_KeyDown(object a_Sender, KeyEventArgs a_Event)
        {
            Keys pressedKey = a_Event.KeyCode;
         
            if (pressedKey == Keys.Add || (pressedKey == Keys.Oemplus && a_Event.Shift))
            {
                OnOperatorPressed(new AddOperator());
            }
            else if (pressedKey == Keys.Subtract || pressedKey == Keys.OemMinus)
            {
                OnOperatorPressed(new SubtractionOperator());
            }
            else if (pressedKey == Keys.Multiply || (pressedKey == Keys.D8 && a_Event.Shift))
            {
                OnOperatorPressed(new MultiplicationOperator());
            }
            else if (pressedKey == Keys.Divide || pressedKey == Keys.OemQuestion)
            {
                OnOperatorPressed(new DivisionOperator());
            }
            else if (pressedKey >= Keys.NumPad0 && pressedKey <= Keys.NumPad9)
            {
                OnDigitPressed((byte)(pressedKey - Keys.NumPad0));
            }
            else if (pressedKey >= Keys.D0 && pressedKey <= Keys.D9)
            {
                OnDigitPressed((byte)(pressedKey - Keys.D0));
            }
            else if (pressedKey == Keys.Return)
            {
                Confirm();
            }
        }

        private ValueBuilder m_ValueBuilder = new ValueBuilder();
        private IExpression m_CurrentExpression;
    }
}
