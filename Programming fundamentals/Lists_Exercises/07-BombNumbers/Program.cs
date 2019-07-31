using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] specialNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bombNumber = specialNums[0];
            int power = specialNums[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {

                    int left = Math.Max(i - power, 0);
                    int right = Math.Min(i + power, numbers.Count - 1);
                    int lenght = right - left + 1;
                    numbers.RemoveRange(left, lenght);
                    i = 0;

                }
            }

            int sumOfNums = numbers.Sum();
            
            Console.WriteLine(sumOfNums);
        }
    }
}
