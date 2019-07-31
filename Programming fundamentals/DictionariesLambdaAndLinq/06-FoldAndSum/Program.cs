using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int k = numbers.Length / 4;

            List<int> row1Left = numbers.Take(k)
                .Reverse()
                .ToList();

            List<int> row1Right = numbers.TakeLast(k)
                .Reverse()
                .ToList();

            List<int> row2 = numbers.Skip(k)
                .Take(2 * k)
                .ToList();

            row1Left = row1Left.Concat(row1Right).ToList();

            List<int> sumOfNums = row1Left.Select((x, index) => x + row2[index])
                .ToList();

            Console.WriteLine(string.Join(" ", sumOfNums));
        }
    }
}
