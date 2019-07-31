using System;
using System.Linq;

namespace _05_RoundingNumbersAwayFromZero
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(x => double.Parse(x))
                .ToArray();
            int[] roundedNums = new int[numbers.Length];
            for (int currNum = 0; currNum < roundedNums.Length; currNum++)
            {
                roundedNums[currNum] = (int)Math.Round(numbers[currNum], MidpointRounding.AwayFromZero);
            }

            for (int currNum = 0; currNum < numbers.Length; currNum++)
            {
                Console.WriteLine($"{numbers[currNum]} => {roundedNums[currNum]}");
            }
        }
    }
}
