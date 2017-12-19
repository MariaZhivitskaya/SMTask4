using System;

namespace SMTask4
{
    class Program
    {
        static void Main(string[] args)
        {
            Integral integral = new Integral();
            Equation equation = new Equation();

            integral.Count1DIntegral();
            integral.Count2DIntegral();
            equation.SolveEquation();
           
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
