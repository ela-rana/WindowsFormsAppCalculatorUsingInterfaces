using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WindowsFormsAppCalculatorUsingInterfaces
{
    internal interface ICalculator
    {
        double Add(double i,double j);
        double Subtract(double i,double j);
        double Multiply(double i,double j);
        double Divide(double i,double j);
    }
    class Calculator : ICalculator
    {
        public double Add(double i, double j)
        {
            return i + j;
        }

        public double Divide(double i, double j)
        {
            return i / j;
        }

        public double Multiply(double i, double j)
        {
            return i * j;
        }

        public double Subtract(double i, double j)
        {
            return i - j;
        }
        public static double Calculate(StringBuilder s)
        {
           //custom error handler for divide by zero
            DivideByZeroHandler(s);

            double result = 0;  //to hold the result of the calculation

            StringBuilder[] mathItem = new StringBuilder[5];    
            //holds [num1],[operator1],[num2],[operator2],[num3]

            int j=0;    //to hold the index location of mathItem
            while(s.Length>0)
            {
                
                
                if ( !Regex.IsMatch(s[0].ToString(), @"[\+\-\/\*]") )   //if its part of the 
                { 
                    mathItem[j].Append(s[0]);
                    s.Remove(0,1);
                    if ( Regex.IsMatch(s[1].ToString(), @"[\+\-\/\*]") )    //if the next char is an operator
                    {
                        if(j==3 && Regex.IsMatch(mathItem[2].ToString(), @"[\/\*]"))
                    }
                }
                //else    //if it is a math operator
                //{
                //    j++;
                //    mathItem[j].Append(s[0]);
                //    s.Remove(0,1);
                //    j++;
                //    if(j==)
               // }

            }











            return result;  //to return the result of the calculation
        }
        public static void DivideByZeroHandler(StringBuilder s)
        {
            StringBuilder temp = new StringBuilder(s.ToString());   //a temp variable to keep a copy of our string
            bool keepChecking = true;   //while loop condition to keep checking every possible instance of divide by zero "/0"
            while (keepChecking && temp.Length > 1)   //as long as the string is not empty
            {
                if (temp.ToString().Contains("/0"))    //if in our arithmetic string we find /0 there might be division by zero
                {
                    if (temp.ToString()[temp.ToString().IndexOf("/0") + 2] != '.') //but if there is a decimal point following the /0
                                                                                   //then that means it is not 0 but 0.--- and decimal number so it is not a divide by zero
                    {
                        //Ex: of this if block: 
                        //5+2/0-1 -> 2/0 is a division by zero
                        //5/0
                        //5/0.4+3-6/0-1  Here the first /0 in "5/0.4" is not a divide by zero but the "6/0" is
                        throw new ArgumentException("Error: Division by zero. Start over");
                    }
                    else
                    {
                        //5/0.4+3-6/0-1
                        //Here the first /0 in "5/0.4" is not a divide by zero but the "6/0" is
                        //thus after finding the first /0 if the exception is not thrown, we will delete everything 
                        //in the temporary StringBuilder upto that /0 so that we can go through the while loop to search 
                        //again for any more /0 instances in the string
                        temp.Remove(0, temp.ToString().IndexOf("/0") + 2);
                        //so after this statement our above example string: 5/0.4+3-6/0-1 becomes
                        //4+3-6/0-1 so then when the loop runs again it will find the next /0 which is an actual divide by
                        //zero and it will throw error
                    }
                }
                else //if /0 wasn't found on this iteration then there are no more possible divide by zeros so we can stop checking
                {
                    keepChecking = false;   //to stop while loop
                }
            }

            StringBuilder[] items = new StringBuilder[5];
            int itemPosition = 0;
            for(int i=0; i<s.Length; i++)
            {
                if (items[i]==)
            }
        }
    }
}

        //Didn't need the following method
        //public static int CountOperators(StringBuilder s)
        //{
        //    int count = 0;
        //    foreach (char c in s.ToString())
        //    {
        //        if (c == '+' || c == '-' || c == '*' || c == '/')
        //            count++;
        //    }
        //    return count;
        //}
        //int operatorCount = CountOperators(s);

//NOTE: Other errors are prevented by the button click event handlers 
//Here is a list of errors not allowed by the button click implementation by enabling/disabling certain button
//clicks after certain other button clicks are made
//1. two decimal points (like "3.2.2") for same number prevented by disabling '.'button after it is pressed until
//next operator or equal to sign is clicked
//2. two back to back operators (like "3/*") not allowed because operators are disabled after one operator is pressed
//and only reenables after another number or decimal point value is entered
//3. the calculation string cannot start or end with operator and cannot end with a decimal point
//Ex: these are not allowed: "/2+1", "2/3+", "2+5."
