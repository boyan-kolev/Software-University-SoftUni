using System;
using System.Collections.Generic;

namespace _03_PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOflines = int.Parse(Console.ReadLine());
            SortedSet<string> chemicalCompounds = new SortedSet<string>();

            for (int counterLine = 0; counterLine < numberOflines; counterLine++)
            {
                string[] input = Console.ReadLine().Split();

                for (int counterCompounds = 0; counterCompounds < input.Length; counterCompounds++)
                {
                    chemicalCompounds.Add(input[counterCompounds]);
                }
            }

            Console.WriteLine(string.Join(" ", chemicalCompounds));
        }
    }
}
