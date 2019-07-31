using System;
using System.Linq;

namespace _06_SumReversedNumbers2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int num = 0; num < numbers.Length; num++)
            {
                string reverseNum = string.Empty;
                while (numbers[num] >= 10)
                {
                    reverseNum += (numbers[num] % 10).ToString();
                    numbers[num] /= 10;
                }
                reverseNum += numbers[num].ToString();
                numbers[num] = int.Parse(reverseNum);
            }

            int sumOfNums = 0;

            foreach (int number in numbers)
            {
                sumOfNums += number;
            }

            Console.WriteLine(sumOfNums);
        }
    }
}
