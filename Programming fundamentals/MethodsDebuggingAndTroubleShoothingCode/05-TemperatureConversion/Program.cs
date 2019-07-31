using System;

namespace _05_TemperatureConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            double fahrenheit = double.Parse(Console.ReadLine());
            double celsius = FahrenheitToCelsius(fahrenheit);
            Console.WriteLine($"{celsius:f2}");
        }

        static double FahrenheitToCelsius(double degrees)
        {
            double celsius = (degrees - 32) * 5 / 9;
            return celsius;
        }
    }
}
