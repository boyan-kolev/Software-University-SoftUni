using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_CountNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            numbers.Sort();

            for (int currNum = 0; currNum < numbers.Count; currNum++)
            {
                int count = 1;
                for (int repeatNum = currNum + 1; repeatNum < numbers.Count; repeatNum++)
                {
                    if (numbers[currNum] == numbers[repeatNum])
                    {
                        count++;
                    }
                }
                Console.WriteLine($"{numbers[currNum]} -> {count}");
                int num = numbers[currNum];   
                numbers.RemoveAll(x => x == num);
                currNum = -1;
            }
        }
    }
}
