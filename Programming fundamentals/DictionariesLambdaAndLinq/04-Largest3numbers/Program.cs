using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Largest3numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(x => double.Parse(x))
                .ToList();

            List<double> largest3 = new List<double>(3);

            largest3 = numbers.OrderByDescending(x => x)
                .Take(3)
                .ToList();

            Console.WriteLine(string.Join(" " ,largest3));
        }
    }
}
