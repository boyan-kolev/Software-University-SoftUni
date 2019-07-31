using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "Delete")
                {
                    int element = int.Parse(command[1]);
                    numbers.RemoveAll(x => x == element);
                }
                else if (command[0] == "Insert")
                {
                    int element = int.Parse(command[1]);
                    int position = int.Parse(command[2]);
                    numbers.Insert(position, element);
                }
                else if (command[0] == "Odd")
                {
                    foreach (int number in numbers)
                    {
                        if (number % 2 != 0)
                        {
                            Console.Write(number + " ");
                        }
                    }
                    Console.WriteLine();
                    return;
                }
                else if (command[0] == "Even")
                {
                    foreach (int number in numbers)
                    {
                        if (number % 2 == 0)
                        {
                            Console.Write(number + " ");
                        }
                    }
                    Console.WriteLine();
                    return;
                }
            }
        }
    }
}
