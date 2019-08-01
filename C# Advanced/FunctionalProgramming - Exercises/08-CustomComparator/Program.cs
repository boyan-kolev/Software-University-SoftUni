using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] evenNumbers = numbers.Where(x => x % 2 == 0).OrderBy(x => x).ToArray();
            int[] oddNumbers = numbers.Where(x => x % 2 != 0).OrderBy(x => x).ToArray();

            Console.WriteLine(string.Join(" ", evenNumbers) + " " + string.Join(" ", oddNumbers));

        }
    }
}
