using System;

namespace _06_CalculateTriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double baseOfTriangle = double.Parse(Console.ReadLine());
            double heightOfTriangle = double.Parse(Console.ReadLine());
            Console.WriteLine(GetArea(baseOfTriangle, heightOfTriangle));
        }

        static double GetArea(double baseTriangle, double height)
        {
            double area = (baseTriangle * height) / 2;
            return area;
        }
    }
}
