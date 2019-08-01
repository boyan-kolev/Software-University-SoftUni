using System;
using System.Linq;

namespace _03_GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[] sizes = new int[3];

            foreach (int number in numbers)
            {
                sizes[Math.Abs(number % 3)]++;
            }

            int[][] jagedArray = new int[3][];

            for (int counter = 0; counter < jagedArray.Length; counter++)
            {
                jagedArray[counter] = new int[sizes[counter]];
            }

            int[] indexes = new int[3];
            
            foreach (int number in numbers)
            {
                int index = Math.Abs(number % 3);
                jagedArray[index][indexes[index]] = number;
                indexes[index]++;
            }

            for (int rows = 0; rows < jagedArray.Length; rows++)
            {
                for (int columns = 0; columns < jagedArray[rows].Length; columns++)
                {
                    Console.Write(jagedArray[rows][columns] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
