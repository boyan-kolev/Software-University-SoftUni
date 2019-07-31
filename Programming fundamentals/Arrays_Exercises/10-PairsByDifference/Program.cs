using System;
using System.Linq;

namespace _10_PairsByDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int different = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    int currDiff = Math.Abs(numbers[i] - numbers[j]);

                    if (different == currDiff)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
