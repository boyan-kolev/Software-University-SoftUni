using System;
using System.Linq;

namespace _04_AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine()
                .Split(", ")
                .Select(p => double.Parse(p, System.Globalization.CultureInfo.InvariantCulture))
                .Select(p => p += (p * 20) / 100)
                .ToArray();

            foreach (double price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }

        }
    }
}
