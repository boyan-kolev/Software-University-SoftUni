using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            if (numbers.Length == 1)
            {
                Console.WriteLine(1);
                return;
            }

            for (int write = 0; write < numbers.Length; write++)
            {
                for (int sort = write + 1; sort < numbers.Length; sort++)
                {
                    if (numbers[write] > numbers[sort])
                    {
                        double temp = numbers[write];
                        numbers[write] = numbers[sort];
                        numbers[sort] = temp;
                    }
                }
            }

            Console.WriteLine(string.Join(" <= ", numbers));
        }
    }
}
