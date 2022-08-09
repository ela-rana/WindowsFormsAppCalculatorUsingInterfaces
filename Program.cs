//Coded using C# Console App on .NET Framework 4.8 on Visual Studio 2022
//A program to do the following:
//Create an interface for ICalculator for methods like add, subtract, divide, multiply and implement them in a class.
//Design a calculator interface to do these basic mathematical calculations allowing functions like “Clear” , “ +” ,”-“
//etc on the calculator interface.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppCalculatorUsingInterfaces
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
