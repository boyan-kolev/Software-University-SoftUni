using System;

namespace _09_LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            PrintLongerLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        static double CalculatePytagorean(double x, double y)
        {
            double result = Math.Sqrt(x * x + y * y);
            return result;
        }

        static void PrintLongerLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double point1 = CalculatePytagorean(x1, y1);
            double point2 = CalculatePytagorean(x2, y2);
            double point3 = CalculatePytagorean(x3, y3);
            double point4 = CalculatePytagorean(x4, y4);

            double line1 = point1 + point2;
            double line2 = point3 + point4;

            if (line1 > line2)
            {
                if (point1 <= point2)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
            else
            {
                if (point3 <= point4)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }

        }
    }
}
