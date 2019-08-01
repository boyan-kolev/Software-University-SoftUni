using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();



            Func<int[], int[]> add = x => x.Select(y => y + 1).ToArray();
            Func<int[], int[]> multiply = x => x.Select(y => y * 2).ToArray();
            Func<int[], int[]> subtract = x => x.Select(y => y - 1).ToArray();
            Action<int[]> printNumbers = x => Console.WriteLine(string.Join(" ", x));

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        printNumbers(numbers);
                        break;
                }
            }

        }
    }
}
