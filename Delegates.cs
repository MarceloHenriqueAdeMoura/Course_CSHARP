using System;

namespace Delegates
{
    class CalculationService
    {
        public static double Max(double x, double y)
        {
            return (x > y) ? x : y;
        }

        public static double Sum(double x, double y)
        {
            return x + y;
        }

        public static double Square(double x)
        {
            return x * x;
        }
    }

    delegate double BinaryNumericOperation(double n1, double n2);

    class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 15;

            BinaryNumericOperation operation = CalculationService.Sum;

            double result = operation(a, b);

            Console.WriteLine(result);
        }
    }
}