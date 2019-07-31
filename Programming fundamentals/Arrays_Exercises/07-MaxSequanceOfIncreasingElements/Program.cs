using System;
using System.Linq;

namespace _07_MaxSequenceOfIncreasingElements
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
            int firrstDigit = 0;
            int leftFirstDigit = 0;
            int diffNum = numbers[1] - numbers[0];
            bool isBigger = true;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if ((numbers[i] < numbers[i + 1]) && diffNum == numbers[i + 1] - numbers[i])
                {
                    if ((length == 1) && (isBigger))
                    {
                        firrstDigit = numbers[i];
                        diffNum = numbers[i + 1] - numbers[i];
                        isBigger = false;
                    }
                    length++;
                }
                else
                {
                    if (length > bestLength)
                    {
                        leftFirstDigit = firrstDigit;
                        bestLength = length;
                        isBigger = true;
                    }
                    diffNum = numbers[i + 2] - numbers[i + 1];
                    length = 1;
                }

                if ((i == numbers.Length - 2) && (length > bestLength))
                {
                    bestLength = length;
                    leftFirstDigit = firrstDigit;
                    diffNum = numbers[i + 1] - numbers[i];

                }
                if ((i == numbers.Length - 2) && (bestLength == 1))
                {
                    leftFirstDigit = numbers[0];
                }
            }

            for (int i = 0; i < bestLength * diffNum; i += diffNum)
            {
                Console.Write(leftFirstDigit + i + " ");
            }
            Console.WriteLine();
        }
    }
}
