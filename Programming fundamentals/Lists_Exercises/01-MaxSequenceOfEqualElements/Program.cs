using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int count = 1;
            int bestCount = 1;
            int start = 0;
            int bestStart = numbers[0];

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        count++;
                        start = numbers[i];
                    }   

                    if (count > bestCount)
                    {
                        bestCount = count;
                        bestStart = start;
                    }
                }
                count = 1;
            }

            for (int i = 0; i < bestCount; i++)
            {
                Console.Write(bestStart + " ");
            }
            Console.WriteLine();
        }
    }
}
