using System;
using System.Linq;

namespace _08_MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            if (numbers.Length == 1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }

            int frequentNum = int.MinValue;
            int length = 1;
            int maxLength = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == frequentNum)
                {
                    continue;
                }
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        length++;
                    }

                }
                if (length > maxLength)
                {
                    frequentNum = numbers[i];
                    maxLength = length;
                    length = 1;
                }
                else
                {
                    length = 1;
                }

            }
            Console.WriteLine(frequentNum);
        }
    }
}
