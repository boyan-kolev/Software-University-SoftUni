using System;
using System.Linq;

namespace _02_DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAndColumns = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rowsAndColumns, rowsAndColumns];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = numbers[columns];
                }
            }

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                primaryDiagonalSum += matrix[rows, rows];
                secondaryDiagonalSum += matrix[rows, matrix.GetLength(1) - rows - 1];
            }

            int sum = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
            Console.WriteLine(sum);
        }
    }
}
