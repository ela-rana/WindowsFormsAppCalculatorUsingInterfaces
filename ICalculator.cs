﻿using System;
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
            int i = 1;
            if (i == 1)
                throw new ArgumentException("well darn that didn't work");
            return 0;
        }
    }
}