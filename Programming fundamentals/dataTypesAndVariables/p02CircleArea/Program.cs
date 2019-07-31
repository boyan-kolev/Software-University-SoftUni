using System;

namespace p02CircleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());
            double circleOfArea = Math.PI * Math.Pow(radius, 2);
            Console.WriteLine($"{circleOfArea:f12}");
        }
    }
}
