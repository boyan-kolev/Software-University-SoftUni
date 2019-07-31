using System;

namespace p03_MilesToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            double inputMiles = double.Parse(Console.ReadLine());
            double oneMile = 1.60934;
            double kilometers = inputMiles * oneMile;
            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
