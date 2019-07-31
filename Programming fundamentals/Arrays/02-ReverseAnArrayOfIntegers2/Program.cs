using System;
using System.Linq;

namespace _02_ReverseAnArrayOfIntegers2
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
            integers = integers.Reverse().ToArray();

            Console.WriteLine(string.Join(' ', integers));
        }
    }
}
