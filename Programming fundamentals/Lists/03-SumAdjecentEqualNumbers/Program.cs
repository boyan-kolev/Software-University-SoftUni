using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_SumAdjecentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            bool isEquals = true;
            while (isEquals)
            {
                isEquals = false;
                for (int i = 0; i < numbers.Count -1; i++)
                {
                    if (numbers[i] == numbers[i + 1])
                    {
                        numbers[i] = numbers[i] + numbers[i + 1];
                        numbers.RemoveAt(i + 1);
                        isEquals = true;
                    }
                }
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
