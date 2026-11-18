Button button = (Button)sender;

if (lblResult.Text == "Cannot Divide by Zero")
{
    lblResult.Text = "0";
    EqualClick = false;
}

//When start calculator
if (lblResult.Text == "0" && !EqualClick)
{
    lblResult.Text = "";
    lblResult.Text += button.Text;
    EnabledButton();
}
else
{
    //if we didn't set the condition as num2 = "0"
    //the firt stage they will get into is the first one

    //When we click on operator button and enter the first number
    if (num1 != 0 && num2 == 0 && !hasNum2)
    {
        lblResult.Text = "";
        lblResult.Text += button.Text;
        hasNum2 = true;
        hasOperatorClicked = false;
        preResult = false;
    }
    //Continue to add another number before we click on operator
    else if (num1 == 0 && !hasNum2 && num2 == 0)
    {
        lblResult.Text += button.Text;
    }
    //Clicked on operator btn and wanna add anoter number after the first number
    else if (num1 != 0 && hasNum2 && num2 == 0 && EqualClick)
    {
        if (lblResult.Text == "0" && EqualClick)
        {
            lblResult.Text = "";
            lblResult.Text += button.Text;
        }
        else
            lblResult.Text += button.Text;
    }
    //Condition for multiple click on equal button and want to calculate with another number
    else if(num1 != 0 && num2 != 0 && preResult)
    {
        num1 = 0;
        num1 = Convert.ToDouble(lblResult.Text);
        lblResult.Text = "";
        lblResult.Text += button.Text;
        hasOperatorClicked = false;
        preResult = false;
    }
    //Change condition after clicked on equal button
    else if (num1 != 0 && num2 != 0)
    {
        if(preResult)
        {
            lblResult.Text = "";
            lblResult.Text += button.Text;
            num1 = 0;
            num2 = 0;
            hasOperatorClicked = false;
        }
        else
            lblResult.Text += button.Text;
    }
    //When we click on only operator btn and clear the number when textbox remain 0
    else if(num1 == 0 && num2 == 0 && !hasNum2 && EqualClick)
    {
        lblResult.Text = "";
        lblResult.Text += button.Text;
        EqualClick = false;
        hasOperatorClicked = false;
    }
}