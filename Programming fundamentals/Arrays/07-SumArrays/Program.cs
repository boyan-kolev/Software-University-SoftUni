using System;
using System.Linq;

namespace _07_SumArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers1 = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

            int[] numbers2 = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();


            int maxLength = Math.Max(numbers1.Length, numbers2.Length);
            int[] sumNumbers = new int[maxLength];

            int[] updateNums = new int[maxLength];

            if (numbers1.Length != maxLength)
            {
                int count = 0;
                for (int i = 0; i < maxLength; i++)
                {
                    if (count >= numbers1.Length)
                    {
                        count = 0;
                    }
                    updateNums[i] = numbers1[count];
                    ++count;
                }

                for (int currNum = 0; currNum < sumNumbers.Length; currNum++)
                {
                    sumNumbers[currNum] = updateNums[currNum] + numbers2[currNum];
                }
            }
            else if (numbers2.Length != maxLength)
            {
                int count = 0;
                for (int i = 0; i < maxLength; i++)
                {
                    if (count >= numbers2.Length)
                    {
                        count = 0;
                    }
                    updateNums[i] = numbers2[count];
                    ++count;
                }

                for (int currNum = 0; currNum < sumNumbers.Length; currNum++)
                {
                    sumNumbers[currNum] = updateNums[currNum] + numbers1[currNum];
                }
            }

            if (numbers1.Length == numbers2.Length)
            {
                for (int currNum = 0; currNum < sumNumbers.Length; currNum++)
                {
                    sumNumbers[currNum] = numbers1[currNum] + numbers2[currNum];
                }
            }

            foreach (int currNum in sumNumbers)
            {
                Console.Write(currNum + " ");
            }
            Console.WriteLine();
        }
    }
}
