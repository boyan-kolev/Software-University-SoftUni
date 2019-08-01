using System;
using System.Linq;

namespace _03_CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> smallestNumber = GetMin;
            int result = smallestNumber(numbers);
            Console.WriteLine(result);
        }

        static int GetMin(int[] numbers)
        {
            int minNumber = int.MaxValue;
            foreach (int number in numbers)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            return minNumber;
        }
    }
}
