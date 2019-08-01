using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int numOfElementsToPush = tokens[0];
            int numOfElementsToPop = tokens[1];
            int searchElement = tokens[2];

            Stack<int> stack = new Stack<int>(elements);

            for (int counterOfEl = 0; counterOfEl < numOfElementsToPop; counterOfEl++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (stack.Contains(searchElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
           

        }
    }
}
