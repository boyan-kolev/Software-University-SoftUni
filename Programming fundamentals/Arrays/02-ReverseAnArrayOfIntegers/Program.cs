using System;

namespace _02_ReverseAnArrayOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfIntegers = int.Parse(Console.ReadLine());
            int[] integers = new int[numberOfIntegers];

            for (int currNum = 0; currNum < integers.Length; currNum++)
            {
                integers[currNum] = int.Parse(Console.ReadLine());
            }

            for (int currNum = 0; currNum < integers.Length / 2; currNum++)
            {
                int tempNum = integers[currNum];
                integers[currNum] = integers[integers.Length - 1 - currNum];
                integers[integers.Length - 1 - currNum] = tempNum;
            }

            for (int currNumber = 0; currNumber < integers.Length; currNumber++)
            {
                Console.Write(integers[currNumber] + " ");
            }
        }
    }
}
