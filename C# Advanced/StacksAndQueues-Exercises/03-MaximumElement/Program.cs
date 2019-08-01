using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int queries = int.Parse(Console.ReadLine());
            Stack<int> elements = new Stack<int>();
            Stack<int> maxElement = new Stack<int>();
            maxElement.Push(int.MinValue);

            for (int query = 0; query < queries; query++)
            {
                int[] tokens = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int queryType = tokens[0];

                switch (queryType)
                {
                    case 1:
                        int element = tokens[1];
                        elements.Push(element);
                        if (maxElement.Peek() <= element)
                        {
                            maxElement.Push(element);
                        }
                        break;
                    case 2:
                        if (maxElement.Peek() == elements.Pop())
                        {
                            maxElement.Pop();
                        }
                        break;
                    case 3:
                        Console.WriteLine(maxElement.Peek());
                        break;
                }
            }
        }
    }
}
