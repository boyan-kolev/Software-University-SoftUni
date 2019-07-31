using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_SumMinMaxAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfNums = int.Parse(Console.ReadLine());
            int[] numbers = new int[countOfNums];

            for (int num = 0; num < countOfNums; num++)
            {
                numbers[num] = (int.Parse(Console.ReadLine()));
            }

            double sum = numbers.Sum();
            int min = numbers.Min();
            int max = numbers.Max();
            int first = numbers.First();
            int last = numbers.Last();
            double average = numbers.Average();

            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Min = " + min);
            Console.WriteLine("Max = " + max);
           //Console.WriteLine("First = " + first);
           //Console.WriteLine("Last = " + last);
            Console.WriteLine("Average = " + average);
        }
    }
}
