using System;
using System.Linq;

namespace _02_RotateAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(num => int.Parse(num))
                .ToArray();
            int k = int.Parse(Console.ReadLine());

            int[] rotateNums = new int[numbers.Length];
            int[] sumNums = new int[numbers.Length];

            for (int index = 0; index < k; index++)
            {
                rotateNums[0] = numbers[numbers.Length - 1];
                for (int i = 1; i < numbers.Length; i++)
                {
                    rotateNums[i] = numbers[i - 1];
                }

                for (int i = 0; i < numbers.Length; i++)
                {
                    sumNums[i] = rotateNums[i] + sumNums[i];
                }

                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = rotateNums[i];
                }
            }

            Console.WriteLine(string.Join(' ', sumNums));
        }
    }
}
