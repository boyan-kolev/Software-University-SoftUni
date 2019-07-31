using System;

namespace _12_RectangleProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side1 = double.Parse(Console.ReadLine());
            double side2 = double.Parse(Console.ReadLine());

            double perimeter = 2 * (side1 + side2);
            double area = side1 * side2;
            double areaPow1 = Math.Pow(side1, 2);
            double areaPow2 = Math.Pow(side2, 2);
            double diagonal = Math.Sqrt(areaPow1 + areaPow2);
            Console.WriteLine(perimeter);
            Console.WriteLine(area);
            Console.WriteLine(diagonal);
        }
    }
}
