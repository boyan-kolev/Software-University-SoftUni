using System;
using System.Linq;

namespace _09_ExtractMiddleElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(num => int.Parse(num))
                .ToArray();

            if (numbers.Length % 2 == 0)
            {
                int[] middleNums = new int[2];
                for (int i = 0; i < middleNums.Length; i++)
                {
                    middleNums[i] = numbers[numbers.Length / 2 - 1 + i];
                }

                String numsStr = String.Join(", ", middleNums);
                Console.WriteLine("{ " + numsStr + " }");
            }
            else if (numbers.Length == 1)
            {
                Console.WriteLine("{ " + numbers[0] + " }");
            }
            else
            {
                int[] middleNums = new int[3];
                for (int i = 0; i < middleNums.Length; i++)
                {
                    middleNums[i] = numbers[numbers.Length / 2 - 1 + i];
                }

                String numsStr = String.Join(", ", middleNums);
                Console.WriteLine("{ " + numsStr + " }");
            }
        }
    }
}
