using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double num1 = 0;
        double num2 = 0;

        string Operator = "";

        bool equalClick = false;
        bool operatorClicked = false;
        bool previousResult = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNum1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if ((lblResult.Text == "Cannot Divide by Zero" || lblResult.Text == "Result is Undefined") 
                || lblResult.Text == "Undefined")
            {
                lblResult.Text = "0";
                equalClick = false;
                EnabledButton();
            }

            if (lblResult.Text == "0")
            {
                if(!operatorClicked)
                {
                    lblResult.Text = "";
                    lblResult.Text += button.Text;
                }
                else
                {
                    lblResult.Text = "";
                    lblResult.Text += button.Text;
                }
            }
            else if (lblResult.Text != "0" && (num1 != 0 || num2 == 0))
            {
                if (previousResult)
                {
                    num1 = 0;
                    num1 = Convert.ToDouble(lblResult.Text);
                    lblResult.Text = "";
                    previousResult = false;
                }
                else if(operatorClicked)
                {
                     lblResult.Text = "";
                }

                lblResult.Text += button.Text;
                operatorClicked = false;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (operatorClicked)
                Operator = button.Text;

            if (!equalClick)
            {
                num1 = Convert.ToDouble(lblResult.Text);
                equalClick = true;
            }
            else
            {
                btnEqual_Click(sender, e);
                previousResult = true;
            }

            Operator = button.Text;
            operatorClicked = true;
            equalClick = true;
            num2 = 0;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (!previousResult)
            {
                num2 = Convert.ToDouble(lblResult.Text);
                previousResult = true;
            }
            else
            {
                num1 = Convert.ToDouble(lblResult.Text);
                operatorClicked = true;
            }

            calculator();
            equalClick = false;
        }

        void EnabledButton()
        {
            Button[] btn =
                { btnCalculate, button11, button12, button13, btnSquare,
                  btnSqrRoot, btnFraction, btnPercentage, btnChange, btnDot };

            if ((lblResult.Text == "Cannot Divide by Zero" || lblResult.Text == "Result is Undefined") 
                || lblResult.Text == "Undefined")
            {
                foreach (var button in btn)
                {
                    button.Enabled = false;
                }
            }
            else if (lblResult.Text != null)
            {
                foreach (var button in btn)
                {
                    button.Enabled = true;
                    num1 = 0;
                    num2 = 0;
                    Operator = "";
                    equalClick = false;
                    operatorClicked = false;
                    previousResult = false;
                }
            }
        }

        void calculator()
        {
            switch (Operator)
            {
                case "+":
                    lblResult.Text = Convert.ToString(num1 + num2);
                    break;
                case "-":
                    lblResult.Text = Convert.ToString(num1 - num2);
                    break;
                case "*":
                    lblResult.Text = Convert.ToString(num1 * num2);
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        lblResult.Text = "Cannot Divide by Zero";
                        if(num1 == 0 && num2 == 0)
                            lblResult.Text = "Result is Undefined";
                            EnabledButton();
                        EnabledButton();
                    }
                    else
                        lblResult.Text = Convert.ToString(num1 / num2);
                    break;
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if(operatorClicked)
            {
                lblResult.Text = "0.";
                operatorClicked = false;
            }

            if (!lblResult.Text.Contains("."))
                lblResult.Text += ".";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblResult.Text = "0";
            EnabledButton();
        }
        private void btnCE_Click(object sender, EventArgs e)
        {
            lblResult.Text = "0";
        }

        private void btnClearOne_Click(object sender, EventArgs e)
        {
            if (equalClick)
                ClearOne();
            else if (operatorClicked)
                lblResult.Text = lblResult.Text;
            else if (num1 != 0 && num2 != 0 && previousResult)
                lblResult.Text = lblResult.Text;
            else
                ClearOne();
        }

        void ClearOne()
        {
            lblResult.Text = lblResult.Text.Substring(0, lblResult.Text.Length - 1);
            if (lblResult.Text.Length == 0)
                lblResult.Text = "0";
        }
        private void btnFraction_Click(object sender, EventArgs e)
        {
            if(lblResult.Text == "0")
            {
                lblResult.Text = "Cannot Divide by Zero";
                EnabledButton();
            }
            else
                lblResult.Text = Convert.ToString(1 / (Convert.ToDouble(lblResult.Text)));
        }
        private void btnSquare_Click(object sender, EventArgs e)
        {
             lblResult.Text = Convert.ToString(Convert.ToDouble(lblResult.Text) * Convert.ToDouble(lblResult.Text));
        }
        private void btnSqrRoot_Click(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(lblResult.Text);

            if (value < 0)
            {
                lblResult.Text = "Undefined";
                EnabledButton();
            }
            else
                lblResult.Text = Math.Sqrt(Convert.ToDouble(lblResult.Text)).ToString();
        }
        private void btnPercentage_Click(object sender, EventArgs e)
        {
            if(equalClick)
            {
                num2 = Convert.ToDouble(lblResult.Text);
                lblResult.Text = Convert.ToString((num1 * num2) / 100);
            }
            else
            {
                lblResult.Text = Convert.ToString((Convert.ToDouble(lblResult.Text)) / 100);
            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            lblResult.Text = Convert.ToString(Convert.ToDouble(lblResult.Text) * (-1));
        }
    }
}
