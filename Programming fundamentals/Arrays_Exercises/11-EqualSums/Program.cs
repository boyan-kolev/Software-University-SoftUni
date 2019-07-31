using System;
using System.Linq;

namespace _11_EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool isEqual = false;

            for (int currNum = 0; currNum < numbers.Length; currNum++)
            {
                int leftSum = 0;
                int rightSum = 0;
                for (int leftNums = 0; leftNums < currNum; leftNums++)
                {
                    leftSum += numbers[leftNums];
                }

                for (int rightNums = currNum + 1; rightNums < numbers.Length; rightNums++)
                {
                    rightSum += numbers[rightNums];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(currNum);
                    isEqual = true;
                    break;
                }
            }

            if (isEqual == false)
            {
                Console.WriteLine("no");
            }
        }
    }
}
