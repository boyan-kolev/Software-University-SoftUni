using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_SquareNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> squareNums = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                double square = Math.Sqrt(numbers[i]);
                if (square == (int)square)
                {
                    squareNums.Add(numbers[i]);
                }
            }

            squareNums.Sort();
            squareNums.Reverse();

            Console.WriteLine(string.Join(" ", squareNums));
        }
    }
}
