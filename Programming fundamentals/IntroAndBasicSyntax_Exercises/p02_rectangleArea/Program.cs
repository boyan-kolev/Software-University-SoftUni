using System;

namespace p02_rectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double sum = width * height; 
            Console.WriteLine($"{sum:f2}");

        }
    }
}
