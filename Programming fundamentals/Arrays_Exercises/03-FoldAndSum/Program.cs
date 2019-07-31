using System;
using System.Linq;

namespace _03_FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            int[] upperArr = new int[numbers.Length / 2];
            int[] lowerArr = new int[numbers.Length / 2];

            for (int i = 0; i < numbers.Length / 4; i++)
            {
                upperArr[i] = numbers[(numbers.Length / 4) - i - 1];
                upperArr[numbers.Length / 4 + i] = numbers[numbers.Length - 1 - i];
            }

            for (int i = 0; i < lowerArr.Length; i++)
            {
                lowerArr[i] = numbers[(lowerArr.Length / 2) + i];
            }

            int[] foldNumbers = new int[lowerArr.Length];
            for (int i = 0; i < foldNumbers.Length; i++)
            {
                foldNumbers[i] = lowerArr[i] + upperArr[i];
            }

            Console.WriteLine(string.Join(" ", foldNumbers));
        }
    }
}
