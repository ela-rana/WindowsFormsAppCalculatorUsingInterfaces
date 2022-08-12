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
        public double Add(double i, double j) { return i + j; }

        public double Divide(double i, double j) { return i / j; }

        public double Multiply(double i, double j) { return i * j; }
    
        public double Subtract(double i, double j) { return i - j; }
        public static void DivideByZeroHandler(StringBuilder s)
        {
            string pattern = @"[\/][0]$|[\/][0][\-\+\*\/]+";
            if (Regex.IsMatch(s.ToString(),pattern))  
                throw new ArgumentException("Error: Division by zero. Start over");
        }
    }
}