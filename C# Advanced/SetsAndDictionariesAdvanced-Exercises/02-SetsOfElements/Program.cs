using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizesOfSets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            FillSet(sizesOfSets[0], set1);
            FillSet(sizesOfSets[1], set2);


            foreach (int number in set1)
            {
                if (set2.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }

            Console.WriteLine();
        }

        private static void FillSet(int sizesOfSets, HashSet<int> set1)
        {
            for (int counter = 0; counter < sizesOfSets; counter++)
            {
                int number = int.Parse(Console.ReadLine());
                set1.Add(number);
            }
        }
    }
}
