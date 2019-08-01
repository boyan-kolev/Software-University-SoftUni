using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfNumbers = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int counter = 0; counter < countOfNumbers; counter++)
            {
                int number = int.Parse(Console.ReadLine());
                if (numbers.ContainsKey(number) == false)
                {
                    numbers.Add(number, 0);
                }

                numbers[number]++;
            }

            int evenTimes = numbers.First(x => x.Value % 2 == 0).Key;

            Console.WriteLine(evenTimes);
        }
    }
}
