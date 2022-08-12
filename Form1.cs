using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsAppCalculatorUsingInterfaces
{   
    public partial class Form1 : Form
    {
        //temporary stringbuilder to hold all user clicks for current calculation
        StringBuilder calcString = new StringBuilder();

        //stringbuilder to hold calculation history
        StringBuilder history = new StringBuilder();

        //A variable to hold the most recent calculation result
        Nullable<double> result;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxCalculation_TextChanged(object sender, EventArgs e)
        {
            //When this calculator first loads a temporary grayed out text: "Calculation" displays as a 
            //placeholder or watermark to describe this textbox
            //thus this event handler ensures when this textbox text is changed, the text color is changed to black
            textBoxCalculation.ForeColor = Color.Black; //change text color to black.
        }
        private void textBoxResultsScreen_TextChanged(object sender, EventArgs e)
        {
            textBoxResultsScreen.ForeColor = Color.Black;
        }

        private void textBoxHistory_TextChanged(object sender, EventArgs e)
        {
            textBoxHistory.ForeColor = Color.Black;
        }

        private void textBoxCalculation_Enter(object sender, EventArgs e)
        {
            //When this calculator first loads a temporary grayed out text: "Calculation" displays as a 
            //placeholder or watermark to describe this textbox
            //thus this event handler ensures when this textbox is entered, the temporary text is cleared
            //and the text color is changed to black
            if (textBoxCalculation.Text == "Calculation")   //if the watermark is currently displaying
            {
                textBoxCalculation.Clear(); //clear the temporary watermark
                textBoxCalculation.ForeColor = Color.Black; //change text color to black.
            }
        }

        private void textBoxResultsScreen_Enter(object sender, EventArgs e)
        {
            //same functionality as the textBoxCalculation_Enter, except that the watermark text displayed here 
            //is "Results Screen"
            if (textBoxResultsScreen.Text == "Results Screen")
            {
                textBoxResultsScreen.Clear();
                textBoxResultsScreen.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Reenables disabled buttons, clears error messages, and updates the Calculation textbox
        /// </summary>
        void RefreshOnNumClick()
        {
            buttonPlus.Enabled = true;
            buttonMinus.Enabled = true;
            buttonDivide.Enabled = true;
            buttonMultiply.Enabled = true;
            buttonEquals.Enabled = true;
            labelErrorMessage.Visible = false;
            textBoxCalculation.Text = calcString.ToString(); //updated calculation stored in calcString is displayed
                                                             //on the Calculation textbox 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            calcString.Append("1"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calcString.Append("2"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calcString.Append("3"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            calcString.Append("4"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            calcString.Append("5"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            calcString.Append("6"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            calcString.Append("7"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            calcString.Append("8"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            calcString.Append("9"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            calcString.Append("0"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            labelErrorMessage.Visible = false;
            buttonPoint.Enabled = false;

            int lastOperatorPosition = 0;
            //error handling to prevent multiple points in same number: For example, 3+2.5.9
            for (int i = calcString.Length - 1; i >= 0; i--)
            {
                if (calcString[i] == '+' || calcString[i] == '-' || calcString[i] == '*' || calcString[i] == '/')
                {
                    lastOperatorPosition = i;
                    break;
                }
            }
            if (calcString.ToString().Substring(lastOperatorPosition).Contains("."))
            {
                labelErrorMessage.Text = "Cannot have more than one point in a number";
            }
            else 
            {
                calcString.Append(".");
                textBoxCalculation.Text = calcString.ToString();
                buttonPlus.Enabled = false;
                buttonMinus.Enabled = false;
                buttonDivide.Enabled = false;
                buttonMultiply.Enabled = false;
                buttonEquals.Enabled = false;
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            buttonPoint.Enabled = true;
            labelErrorMessage.Visible = false;
            if (calcString.Length <= 0)
            {
                labelErrorMessage.Visible = true;
                if (result != null)
                {
                    labelErrorMessage.Text =
                    "You added your operator before any value.\nThe previous calculation's result will be used as the first operator";
                    calcString.Append(result);
                    calcString.Append("+");
                }
                else
                {
                    labelErrorMessage.Text =
                    "You cannot start your expression with an operator.\nPlease add a value before your arithmetic operator";
                }
            }
            else
            {
                calcString.Append("+");
            }
            textBoxCalculation.Text = calcString.ToString();
            buttonPlus.Enabled = false;
            buttonMinus.Enabled = false;
            buttonDivide.Enabled = false;
            buttonMultiply.Enabled = false;
            buttonEquals.Enabled = false;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            buttonPoint.Enabled = true;
            labelErrorMessage.Visible = false;
            if (calcString.Length <= 0)
            {
                labelErrorMessage.Visible = true;
                if (result != null) 
                {
                    labelErrorMessage.Text =
                    "You added your operator before any value.\nThe previous calculation's result will be used as the first operator";
                    calcString.Append(result);
                    calcString.Append("-");
                }
                else
                {
                    labelErrorMessage.Text =
                    "You cannot start your expression with an operator.\nPlease add a value before your arithmetic operator";
                }
            }
            else
            {
                calcString.Append("-");
            }
            textBoxCalculation.Text = calcString.ToString();
            buttonPlus.Enabled = false;
            buttonMinus.Enabled = false;
            buttonDivide.Enabled = false;
            buttonMultiply.Enabled = false;
            buttonEquals.Enabled = false;

        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            buttonPoint.Enabled = true;
            labelErrorMessage.Visible = false;
            if (calcString.Length <= 0)
            {
                labelErrorMessage.Visible = true;
                if (result != null)
                {
                    labelErrorMessage.Text =
                    "You added your operator before any value.\nThe previous calculation's result will be used as the first operator";
                    calcString.Append(result);
                    calcString.Append("*");
                }
                else
                {
                    labelErrorMessage.Text =
                    "You cannot start your expression with an operator.\nPlease add a value before your arithmetic operator";
                }
            }
            else
            {
                calcString.Append("*");
            }
            textBoxCalculation.Text = calcString.ToString();
            buttonPlus.Enabled = false;
            buttonMinus.Enabled = false;
            buttonDivide.Enabled = false;
            buttonMultiply.Enabled = false;
            buttonEquals.Enabled = false;

        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            buttonPoint.Enabled = true;
            labelErrorMessage.Visible = false;
            if (calcString.Length <= 0)
            {
                labelErrorMessage.Visible = true;
                if (result != null)
                {
                    labelErrorMessage.Text =
                    "You added your operator before any value.\nThe previous calculation's result will be used as the first operator";
                    calcString.Append(result);
                    calcString.Append("/");
                }
                else
                {
                    labelErrorMessage.Text =
                    "You cannot start your expression with an operator.\nPlease add a value before your arithmetic operator";
                }
            }
            else
            {
                calcString.Append("/");
            }
            textBoxCalculation.Text = calcString.ToString();
            buttonPlus.Enabled = false;
            buttonMinus.Enabled = false;
            buttonDivide.Enabled = false;
            buttonMultiply.Enabled = false;
            buttonEquals.Enabled = false;

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            labelErrorMessage.Visible = false;

            //the back button is treated like a backspace button. So if it is clicked, the most recent entered
            //button click stored in calcString is deleted by reducing the stringbuilder length by 1 
            //which wipes out the last character

            if (calcString.Length > 0)  //as long as there is something to backspace
            {
                if (calcString.ToString().EndsWith("."))    //before pressing back if the last digit was a decimal
                                                            //then after backspacing and clearing out that decimal,
                                                            //the decimal, equals and operator button which would
                                                            //have been disabled by point button click should be reenabled
                {
                    buttonPoint.Enabled = true;
                    buttonPlus.Enabled = true;
                    buttonMinus.Enabled = true;
                    buttonDivide.Enabled = true;
                    buttonMultiply.Enabled = true;
                    buttonEquals.Enabled = true;
                }
                else if (calcString.ToString().EndsWith("+") || calcString.ToString().EndsWith("-") ||
                          calcString.ToString().EndsWith("*") || calcString.ToString().EndsWith("/"))
                //if before backspacing the last entered value is an operator, then we need to re-enable
                //all the buttons that that operator would have disabled
                {
                    buttonPlus.Enabled = true;
                    buttonMinus.Enabled = true;
                    buttonDivide.Enabled = true;
                    buttonMultiply.Enabled = true;
                    buttonEquals.Enabled = true;
                }
                calcString.Length--;    //decrement stringbuilder size by 1
                textBoxCalculation.Text = calcString.ToString(); //display updated calcString in Calculation textbox
                if (calcString.ToString().EndsWith(".")) //if after backspacing the last entered value is a decimal point
                            //then we need to re-disable all the buttons that should not be pressed after a decimal point
                {
                    buttonPoint.Enabled = false;
                    buttonPlus.Enabled = false;
                    buttonMinus.Enabled = false;
                    buttonDivide.Enabled = false;
                    buttonMultiply.Enabled = false;
                    buttonEquals.Enabled = false;
                }
                else if ( calcString.ToString().EndsWith("+") || calcString.ToString().EndsWith("-") ||
                          calcString.ToString().EndsWith("*") || calcString.ToString().EndsWith("/") )
                //if after backspacing the last entered value is an operator, then we need to re-disable
                //all the buttons that should not be pressed after an operator, such as another operator or the equals button
                {
                    buttonPlus.Enabled = false;
                    buttonMinus.Enabled = false;
                    buttonDivide.Enabled = false;
                    buttonMultiply.Enabled = false;
                    buttonEquals.Enabled = false;
                }

            }
            else //if the string was already empty (nothing to backspace), then an error is displayed in the label
            {
                labelErrorMessage.Visible = true;
                labelErrorMessage.Text = "Nothing present to backspace";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Exits the application
            Application.Exit();
        }

        /// <summary>
        /// Event handler that makes the system calculate when the equal to button is clicked.
        /// Result is displayed on result textbox and added to history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            try
            {
                result = Calculate(calcString);
                textBoxResultsScreen.Text = result.ToString();

            }
            catch (Exception ex)
            {
                textBoxResultsScreen.Text = "Error";
                MessageBox.Show(ex.Message);
                result = null;
            }
            history.Append(calcString.ToString());
            history.Append("=");
            history.Append(result);
            history.AppendLine();
            textBoxHistory.Text = history.ToString();
            calcString.Clear();
            buttonPoint.Enabled = true;
        }

        private void buttonClearCalculation_Click(object sender, EventArgs e)
        {
            calcString.Clear();
            textBoxCalculation.Clear();
        }

        private void buttonClearHistory_Click(object sender, EventArgs e)
        {
            textBoxHistory.Clear();
            textBoxCalculation.Clear();
            textBoxResultsScreen.Clear();     
            history.Clear();
            calcString.Clear();
            result = null;
        }
        public static double Calculate(StringBuilder s)
        {            
            double calcResult = 0;  //to hold the result of the calculation at each step, in the end it will end up with the final calculation result 

            //custom error handler for divide by zero first
            Calculator.DivideByZeroHandler(s);

            Calculator calc = new Calculator();
            string pattern = @"[\+\-\/\*]|[\d\.]+"; //pattern string: finds each double number or operator 
            MatchCollection matches = Regex.Matches(s.ToString(), pattern); //saves every number/operator item in our expression
            List<StringBuilder> list = new List<StringBuilder>();   //a list to hold the values in the match collection
            foreach (Match m in matches)
            {
                list.Add(new StringBuilder(m.ToString()));  //to add each item in the math expression to list as a stringbuilder
            }

            //list.RemoveRange(6, 3);
            //list.Insert(6, new StringBuilder("2345"));
            //foreach (StringBuilder sb in list)
            //    Console.WriteLine(sb.ToString());
            int i = 1;  //index of list

            //since multiply and divide takes priority over add and subtract, the first while loop goes through and performs * and / 
            //operations only from left to right
            while (i < list.Count())
            {
                if (list[i].ToString() == "*" || list[i].ToString() == "/")
                {
                    if (list[i].ToString() == "*")
                        calcResult = calc.Multiply( Double.Parse(list[i - 1].ToString()) , Double.Parse(list[i + 1].ToString()) );
                            // Double.Parse(list[i - 1].ToString()) * Double.Parse(list[i + 1].ToString());
                    else
                        calcResult = calc.Divide(Double.Parse(list[i - 1].ToString()), Double.Parse(list[i + 1].ToString()));
                    list.RemoveRange(i - 1, 3);
                    list.Insert(i - 1, new StringBuilder(calcResult.ToString()));
                }
                else
                    i++;
            }
            i = 1;  //to go through an do the remaining operations (+ and -) starting back from 1 (the first possible location of an operator
            while (i < list.Count())
            {
                if (list[i].ToString() == "+" || list[i].ToString() == "-")
                {
                    if (list[i].ToString() == "+")
                        calcResult = calc.Add(Double.Parse(list[i - 1].ToString()), Double.Parse(list[i + 1].ToString()));
                    else
                        calcResult = calc.Subtract(Double.Parse(list[i - 1].ToString()), Double.Parse(list[i + 1].ToString()));
                    list.RemoveRange(i - 1, 3);
                    list.Insert(i - 1, new StringBuilder(calcResult.ToString()));
                }
                else
                    i++;
            }

            return calcResult;  //to return the result of the calculation
        }
    }
}
