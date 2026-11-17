using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double num1 = 0;
        double num2 = 0;

        string Operator = "";

        bool hasNum2 = false;
        bool EqualClick = false;
        bool hasOperatorClicked = false;
        bool preResult = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNum1_Click(object sender, EventArgs e)
        { 
            Button button = (Button)sender;

            if (txtResult.Text == "Cannot Divide by Zero")
            {
                txtResult.Text = "0";
            }

            //When start calculator
            if (txtResult.Text == "0" && EqualClick == false)
            {
                txtResult.Text = "";
                txtResult.Text += button.Text;
            }
            else
            {
                //if we didn't set the condition as num2 = "0"
                //the firt stage they will get into is the first one

                //When we click on operator button and enter the first number
                if (num1 != 0 && hasNum2 == false && num2 == 0)
                {
                    txtResult.Text = "";
                    txtResult.Text += button.Text;
                    hasNum2 = true;
                    hasOperatorClicked = false;
                    preResult = false;
                }
                //Continue to add another number before we click on operator
                else if (num1 == 0 && hasNum2 == false && num2 == 0)
                {
                    txtResult.Text += button.Text;
                }
                //Clicked on operator btn and wanna add anoter number after the first number
                else if (num1 != 0 && hasNum2 == true && num2 == 0 && EqualClick == true)
                {
                    if (txtResult.Text == "0" && EqualClick == true)
                    {
                        txtResult.Text = "";
                        txtResult.Text += button.Text;
                    }
                    else
                    {
                        txtResult.Text += button.Text;
                    }
                }
                //Condition for multiple click on equal button and want to calculate with another number
                else if(num1 != 0 && num2 != 0 && preResult == true)
                {
                    num1 = 0;
                    num1 = Convert.ToDouble(txtResult.Text);
                    txtResult.Text = "";
                    txtResult.Text += button.Text;
                    hasOperatorClicked = false;
                    preResult = false;
                }
                //Change condition after clicked on equal button
                else if (num1 != 0 && num2 != 0)
                {
                    txtResult.Text = "";
                    txtResult.Text += button.Text;
                    num1 = 0;
                    num2 = 0;
                    hasOperatorClicked = false;
                }
                //When we click on only operator btn and clear the number when textbox remain 0
                else if(num1 == 0 && hasNum2 == false && num2 == 0 && EqualClick == true)
                {
                    txtResult.Text = "";
                    txtResult.Text += button.Text;
                    EqualClick = false;
                    hasOperatorClicked = false;
                }
            }
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            //controll when users try to press on operator button multiple times
            if (hasOperatorClicked)
            {
                Operator = button.Text;
                return;
            }

            //To hold the number when press on operator button after press on equal button
            if(!hasNum2)
            {
                EqualClick = false;
            }
            else
            {
                EqualClick = true;
            }

            //The first operator
            if (EqualClick == false)
            {
                num1 = Convert.ToDouble(txtResult.Text);
                EqualClick = true;
            }
            //Click on another operator and auto calculate the result
            else if (EqualClick == true)
            {
                btnEqual_Click(sender, e);
                num1 = Convert.ToDouble(txtResult.Text);
                hasOperatorClicked = true;
                preResult = true;
            }

            Operator = button.Text;

            num2 = 0;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            Button[] btn = { btnSum, button11, button12, button13, btnSquare, btnSqrRoot, btnFraction, btnPercentage };

            if (txtResult.Text == "Cannot Divide by Zero")
            {
                foreach (var button in btn)
                {
                    button.Enabled = true;
                }
            }

            //first press on equal button
            if (preResult == false)
            {
                num2 = Convert.ToDouble(txtResult.Text);
                calculator();
                EqualClick = true;
                preResult = true;
            }
            //multiple calculate number and press on operator instead on equal button
            else if (preResult == true)
            {
                num1 = Convert.ToDouble(txtResult.Text);
                calculator();
                hasOperatorClicked = true;
                EqualClick = true;
            }

            //EqualClick = true;
            hasNum2 = false;
        }

        void calculator()
        {     
            switch (Operator)
            {
                case "+":
                    txtResult.Text = Convert.ToString(num1 + num2);
                    break;
                case "-":
                    txtResult.Text = Convert.ToString(num1 - num2);
                    break;
                case "*":
                    txtResult.Text = Convert.ToString(num1 * num2);
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        txtResult.Text = "Cannot Divide by Zero";
                    }
                    else
                    {
                        txtResult.Text = Convert.ToString(num1 / num2);
                    }
                    break;
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (txtResult.Text.Contains(".") == false)
            {
                txtResult.Text += ".";
            }
        } 

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            num1 = 0;
            num2 = 0;
            Operator = "";
            hasNum2 = false;
            EqualClick = false;
            hasOperatorClicked = false;
            preResult = false;
        }

        private void btnClearOne_Click(object sender, EventArgs e)
        {
            if (EqualClick == true)
            {
                if (hasOperatorClicked == false)
                {
                    if (num1 == 0)
                    {
                        txtResult.Text = txtResult.Text;
                    }
                    else if(num1 != 0 && num2 != 0 && hasOperatorClicked == false)
                    {
                        txtResult.Text = txtResult.Text;
                    }
                    else if(num1 == 0 && EqualClick == true)
                    {
                        ClearOne();
                    }
                    else if(num1 != 0 && EqualClick == true && hasOperatorClicked == true)
                    {
                        txtResult.Text = txtResult.Text;
                    }
                    else if(num1 != 0 && hasOperatorClicked == false)
                    {
                        ClearOne();
                    }
                }
                else 
                {
                    ClearOne();
                }
            }
            else
            {
                ClearOne();
            }
        }

        void ClearOne()
        {
            txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1);

            if (txtResult.Text.Length == 0)
            {
                txtResult.Text = "0";
            }
        }

        private void btnFraction_Click(object sender, EventArgs e)
        {
            txtResult.Text = Convert.ToString(1/(Convert.ToDouble(txtResult.Text)));
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            txtResult.Text = Convert.ToString(Convert.ToDouble(txtResult.Text) * Convert.ToDouble(txtResult.Text));
        }

        private void btnSqrRoot_Click(object sender, EventArgs e)
        {
            txtResult.Text = Math.Sqrt(Convert.ToDouble(txtResult.Text)).ToString();
        }

        private void btnPercentage_Click(object sender, EventArgs e)
        {
            txtResult.Text = Convert.ToString((Convert.ToDouble(txtResult.Text)) / 100);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            txtResult.Text = Convert.ToString(Convert.ToDouble(txtResult.Text) * (-1));
        }
    }
}
