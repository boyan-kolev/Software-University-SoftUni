using System;
using System.Linq;

namespace _04_MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensionalOfMatrix = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[dimensionalOfMatrix[0], dimensionalOfMatrix[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] row = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = row[columns];
                }
            }

            int sum = int.MinValue;
            int rowIndex = 0;
            int columnIndex = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 2; rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1) - 2; columns++)
                {
                    int currSum = matrix[rows, columns]
                        + matrix[rows, columns + 1]
                        + matrix[rows, columns + 2]
                        + matrix[rows + 1, columns]
                        + matrix[rows + 1, columns + 1]
                        + matrix[rows + 1, columns + 2]
                        + matrix[rows + 2, columns]
                        + matrix[rows + 2, columns + 1]
                        + matrix[rows + 2, columns + 2];

                    if (currSum > sum)
                    {
                        sum = currSum;
                        rowIndex = rows;
                        columnIndex = columns;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");

            for (int rows = rowIndex; rows < rowIndex + 3; rows++)
            {
                for (int columns = columnIndex; columns < columnIndex + 3; columns++)
                {
                    Console.Write(matrix[rows, columns] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
