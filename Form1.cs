using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double num1 = 0;
        double num2 = 0;
        string Operator = "";
        bool equalClicked = false;
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
                EnabledButton();
                Reset();
            }

            if (lblResult.Text == "0")
            {
                lblResult.Text = "";
                lblResult.Text += button.Text;
            }
            else if (lblResult.Text != "0" && (num1 != 0 || num2 == 0))
            {
                if (previousResult)
                {
                    num1 = 0;
                    num1 = Convert.ToDouble(lblResult.Text);

                    lblResult.Text = "";
                    previousResult = false;
                    equalClicked = true;
                }
                else if (operatorClicked)
                {
                    lblResult.Text = "";
                    operatorClicked = false;
                }
                lblResult.Text += button.Text;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Operator = button.Text;

            if (operatorClicked)
            {
                Operator = button.Text;
                return;
            }

            if(!operatorClicked && !equalClicked)
            {
                num1 = Convert.ToDouble(lblResult.Text);
                operatorClicked = true;
                previousResult = false;
                equalClicked = true;
            }
            else if(!previousResult && equalClicked)
            {
                operatorClicked = true;
                btnEqual_Click(sender,e);
            }
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (previousResult)
            {
                case false: 
                    num2 = Convert.ToDouble(lblResult.Text);
                    Calculator();
                    previousResult = true;
                    operatorClicked = false;
                    equalClicked = false;
                    break;
                case true: 
                    num1 = Convert.ToDouble(lblResult.Text);
                    Calculator();
                    operatorClicked = false;
                    break;
            }
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
                }
            }
        }

        void Reset()
        {
            num1 = 0;
            num2 = 0;
            Operator = "";
            equalClicked = false;
            operatorClicked = false;
            previousResult = false;
        }

        void Calculator()
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
            Reset();
        }
        private void btnCE_Click(object sender, EventArgs e)
        {
            lblResult.Text = "0";
        }

        private void btnClearOne_Click(object sender, EventArgs e)
        {
            if (previousResult || operatorClicked)
                return;
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
            if(equalClicked)
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
