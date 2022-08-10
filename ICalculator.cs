using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //STEP 1: ERROR HANDLING FOR DIVIDE BY ZERO WITHIN OUR STRING
            StringBuilder temp = new StringBuilder(s.ToString());   //a temp variable to keep a copy of our string
            bool keepChecking = true;   //while loop condition to keep checking every possible instance of divide by zero "/0"
            while (keepChecking && temp.Length>1)   //as long as the string is not empty
            {
                if (temp.ToString().Contains("/0") )    //if in our arithmetic string we find /0 there might be division by zero
                {
                    if(temp.ToString()[temp.ToString().IndexOf("/0") + 2] != '.') //but if there is a decimal point following the /0
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

            //STEP 2: ERROR HANDLING

            double result = 0;

            //Nullable<double>[] values = new Nullable<double>[20];
            return result;
        }
    }
}
