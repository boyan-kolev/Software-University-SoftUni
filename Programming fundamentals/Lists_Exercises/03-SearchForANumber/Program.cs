using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_SearchForANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] manipulationNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            

            int takeElements = manipulationNums[0];
            int deleteElement = manipulationNums[1];
            int searchElement = manipulationNums[2];

            for (int i = takeElements; i < numbers.Count; i++)
            {
                numbers.RemoveAt(i);
            }

            for (int i = 0; i < deleteElement; i++)
            {
                numbers.RemoveAt(0);
                
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (searchElement == numbers[i])
                {
                    Console.WriteLine("YES!");
                    return;
                }
            }

            Console.WriteLine("NO!");
        }
    }
}
