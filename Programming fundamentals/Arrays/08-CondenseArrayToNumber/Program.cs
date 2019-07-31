using System;
using System.Linq;

namespace _08_CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

            while (numbers.Length > 1)
            {
                int[] condense = new int[numbers.Length - 1];
                for (int position = 0; position < condense.Length; position++)
                {
                    condense[position] = numbers[position] + numbers[position + 1];
                }
                numbers = condense;
            }

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
