using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// counterdoubleClick bug 
// click=number
// clean code, OOP
namespace Calculator
{
    public partial class Form1 : Form
    {
        string _resultValue;
        string _operationPerformed = "";
        string _operandFirst = string.Empty, _operandSecond = string.Empty;
        bool _isOperationPerformed = false;
        int counterOperatorClick = 0;
        bool counterdoubleClick = true;
        string _a = string.Empty, _b = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            counterdoubleClick = true;
            if (txtResult.Text == "0" || _isOperationPerformed)
                txtResult.Clear();
            _isOperationPerformed = false;
            Button button = (Button)sender;

            if (button.Text == ",")
            {
                if (!txtResult.Text.Contains(","))
                    txtResult.Text += button.Text;
            }
            else
                txtResult.Text += button.Text;

        }
        private void operator_click(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;

            if (lblcurrentOperation.Text.Contains("="))
            {
                _operationPerformed = button.Text;
                operand_initialization();
                counterOperatorClick++;
            }

                if (counterdoubleClick)
                {
                    double res;
                    double.TryParse(_resultValue, out res);
                    if (res != 0)
                    {
                    
                        btnEqual.PerformClick();
                        _operationPerformed = button.Text;
                        operand_initialization();

                    }
                    else
                    {
                        if (counterOperatorClick != 0)
                        {
                            btnEqual.PerformClick();
                            _operationPerformed = button.Text;
                            lblcurrentOperation.Text = txtResult.Text + " " + _operationPerformed;
                            _isOperationPerformed = true;

                        }
                        else
                        {
                            _operationPerformed = button.Text;
                            operand_initialization();
                            counterOperatorClick++;
                        }
                    }
                } 
            
            counterdoubleClick = false;
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblcurrentOperation.Text.Contains("="))
            {
                _operandSecond = _b;
            }
            else
            _operandSecond = txtResult.Text;            
            double opr1, opr2;
            double.TryParse(_operandFirst, out opr1);
            double.TryParse(_operandSecond, out opr2);

            switch (_operationPerformed)
            {
                case "+":
                    _resultValue = (opr1 + opr2).ToString();
                    break;
                case "-":
                    _resultValue = (opr1 - opr2).ToString();
                    break;
                case "*":
                    _resultValue = (opr1 * opr2).ToString();
                    break;
                case "/":
                    _resultValue = (opr1 / opr2).ToString();
                    break;
                case "mod":
                    _resultValue = (opr1 % opr2).ToString();
                    break;                   
            }
            
            _a = _operandFirst;
            _b = _operandSecond;
            txtResult.Text = _resultValue;
            _operandFirst = _resultValue;
            lblcurrentOperation.Text = string.Format($"{_a} {_operationPerformed} {_b} = ");            
        }
        private void operand_initialization()
        {
            counterdoubleClick = false;
            _operandFirst = txtResult.Text;
            lblcurrentOperation.Text = _operandFirst + " " + _operationPerformed;
            _isOperationPerformed = true;
            
        }
        private void btnNegative_Click(object sender, EventArgs e)
        {
            txtResult.Text = (-1 * double.Parse(txtResult.Text)).ToString();
            _resultValue = txtResult.Text;
        }
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1);

            if (txtResult.Text.Length == 0)
            {
                txtResult.Text = "0";
            }

        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            txtResult.Text = Math.Sqrt(double.Parse(txtResult.Text)).ToString();
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            double.TryParse(txtResult.Text, out double x);
            txtResult.Text = (x * x).ToString();
        }
       
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //SendKeys.Send("{NUMLOCK}");
            switch (e.KeyCode)
            {
                case Keys.D0:
                    btnZero.PerformClick();
                    break;

                case Keys.NumPad1:
                case Keys.D1:                
                    btnOne.PerformClick();
                    break;

                case Keys.NumPad2:
                case Keys.D2:
                    btnTwo.PerformClick();
                    break;

                case Keys.NumPad3:
                case Keys.D3:
                    btnThree.PerformClick();
                    break;

                case Keys.NumPad4:
                case Keys.D4:
                    btnFour.PerformClick();
                    break;

                case Keys.NumPad5:
                case Keys.D5:
                    btnFive.PerformClick();
                    break;

                case Keys.NumPad6:
                case Keys.D6:
                    btnSix.PerformClick();
                    break;

                case Keys.NumPad7:
                case Keys.D7:
                    btnSeven.PerformClick();
                    break;

                case Keys.NumPad8:
                case Keys.D8:
                    btnEight.PerformClick();
                    break;

                case Keys.NumPad9:
                case Keys.D9:
                    btnNine.PerformClick();
                    break;

                case Keys.Enter:
                    btnEqual.PerformClick();                    
                    break;

                case Keys.OemMinus:                    
                    btnMinus.PerformClick();
                    break;

                case Keys.Oemplus:
                    btnPilus.PerformClick();
                    break;

                case Keys.OemPipe:
                    btnMinus.PerformClick();
                    break;
                default:
                    break;
            }
        }
        
    private void btnCE_Click(object sender, EventArgs e)
        {

            txtResult.Text = "0";
            counterOperatorClick = 0;
        }
        private void btnC_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            _resultValue = string.Empty;
            _operandFirst = string.Empty;
            lblcurrentOperation.Text = string.Empty;
            counterOperatorClick = 0;

        }
    }
}
