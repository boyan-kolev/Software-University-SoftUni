using System;
using System.Collections.Generic;

namespace _06_TrafficLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsThatCanPassed = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int carsPassed = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    Console.WriteLine($"{carsPassed} cars passed the crossroads.");
                    return;
                }
                else if (input == "green")
                {
                    int length = Math.Min(carsThatCanPassed, queue.Count);
                    for (int counter = 0; counter < length; counter++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        carsPassed++;
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }

            }
        }
    }
}
