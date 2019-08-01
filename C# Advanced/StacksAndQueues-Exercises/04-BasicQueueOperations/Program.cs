using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_BasicQueueOperations
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

            int numOfDequeueElements = tokens[1];
            int target = tokens[2];
            Queue<int> queueOfElements = new Queue<int>(elements);

            for (int countOfElements = 0; countOfElements < numOfDequeueElements; countOfElements++)
            {
                queueOfElements.Dequeue();
            }

            if (queueOfElements.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (queueOfElements.Contains(target))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queueOfElements.Min());
            }

        }
    }
}
