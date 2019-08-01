using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> countOfValues = new Dictionary<double, int>();

            foreach (double value in values)
            {
                if (countOfValues.ContainsKey(value) == false)
                {
                    countOfValues.Add(value, 0);
                }

                countOfValues[value]++;
            }

            foreach (var kvp in countOfValues)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
