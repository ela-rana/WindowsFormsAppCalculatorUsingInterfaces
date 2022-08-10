using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            calcString.Append("1"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            calcString.Append("1"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            calcString.Append("1"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            calcString.Append("1"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            calcString.Append("1"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            calcString.Append("1"); //every button click is converted to a string and added to calcString
            RefreshOnNumClick();
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            labelErrorMessage.Visible = false;
            calcString.Append(".");
            textBoxCalculation.Text = calcString.ToString();
            buttonPoint.Enabled = false;
            buttonPlus.Enabled = false;
            buttonMinus.Enabled = false;
            buttonDivide.Enabled = false;
            buttonMultiply.Enabled = false;
            buttonEquals.Enabled = false;
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
                    "You cannot start your expression with a string.\nPlease add a value before your arithmetic operator";
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
                    "You cannot start your expression with a string.\nPlease add a value before your arithmetic operator";
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
                    "You cannot start your expression with a string.\nPlease add a value before your arithmetic operator";
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
                    "You cannot start your expression with a string.\nPlease add a value before your arithmetic operator";
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
            if (calcString.Length > 0)
            {
                calcString.Length--;    //decrement stringbuilder size by 1
                textBoxCalculation.Text = calcString.ToString(); //display updated calcString in Calculation textbox
                if(calcString.ToString().EndsWith("."))
                {
                    buttonPoint.Enabled = false;
                    buttonPlus.Enabled = false;
                    buttonMinus.Enabled = false;
                    buttonDivide.Enabled = false;
                    buttonMultiply.Enabled = false;
                    buttonEquals.Enabled = false;
                }
            }
            else
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
                result = Calculator.Calculate(calcString);
                textBoxResultsScreen.Text = result.ToString();

            }
            catch (Exception)
            {
                textBoxResultsScreen.Text = "Error: Division by zero.Start over";
                result = null;
            }
            history.Append(calcString.ToString());
            history.Append("=");
            history.Append(result);
            history.AppendLine();
            textBoxHistory.Text = history.ToString();
            calcString.Clear();
        }

        private void buttonClearCalculation_Click(object sender, EventArgs e)
        {
            calcString.Clear();
            textBoxCalculation.Clear();
        }

        private void buttonClearHistory_Click(object sender, EventArgs e)
        {
            history.Clear();
            textBoxHistory.Clear();
        }
    }
}
