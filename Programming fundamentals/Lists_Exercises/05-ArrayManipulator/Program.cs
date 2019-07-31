using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(num => int.Parse(num))
                .ToList();


            while (true)
            {
                List<string> command = Console.ReadLine()
                    .Split()
                    .ToList();

                if (command[0] == "add")
                {
                    int index = int.Parse(command[1]);
                    int element = int.Parse(command[2]);
                    numbers.Insert(index, element);
                }
                else if (command[0] == "addMany")
                {
                    int index = int.Parse(command[1]);
                    List<int> elements = new List<int>();

                    for (int i = 2; i < command.Count; i++)
                    {
                        elements.Add(int.Parse(command[i]));
                    }

                    numbers.InsertRange(index, elements);
                }
                else if (command[0] == "contains")
                {
                    int element = int.Parse(command[1]);
                    int positionOfEl = numbers.IndexOf(element);
                    Console.WriteLine(positionOfEl);
                    
                }
                else if (command[0] == "remove")
                {
                    int index = int.Parse(command[1]);
                    numbers.RemoveAt(index);
                }
                else if (command[0] == "shift")
                {
                    int positions = int.Parse(command[1]) % numbers.Count;
                    numbers = ShiftElements(numbers, positions);
                }
                else if (command[0] == "sumPairs")
                {
                    numbers = SumPairs(numbers);
                }
                else if (command[0] == "print")
                {
                    Console.WriteLine("[" + (string.Join(", ", numbers)) + "]");
                    return;
                }

            }
        }


        static List<int> ShiftElements(List<int> nums, int positions)
        {
            List<int> manipNums = new List<int>();
            for (int i = 0; i < positions; i++)
            {
                manipNums.Add(nums[0]);
                nums.RemoveAt(0);
            }

            nums.AddRange(manipNums);

            return nums;
        }

        static List<int> SumPairs(List<int> nums)
        {
            List<int> sumNums = new List<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                if ((i + 2) <= nums.Count)
                {
                    sumNums.Add(nums[i] + nums[i + 1]);
                    i++;
                }
                else
                {
                    sumNums.Add(nums[nums.Count - 1]);
                }
            }
            return sumNums;
        }
    }
}
