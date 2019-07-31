using System;
using System.Linq;

namespace _06_MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int length = 1;
            int bestLength = 1;
            int repeatNum = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    length++;
                }
                else
                {
                    if (length > bestLength)
                    {
                        bestLength = length;
                        repeatNum = numbers[i];
                    }
                    length = 1;

                }

                if ((i == numbers.Length - 2) && (length > bestLength))
                {
                    bestLength = length;
                    repeatNum = numbers[i];
                }
                else if ((i == numbers.Length - 2) && (bestLength == 1))
                {
                    repeatNum = numbers[0];
                }

            }


            for (int i = 0; i < bestLength; i++)
            {
                Console.Write(repeatNum + " ");
            }
            Console.WriteLine();
        }
    }
}
