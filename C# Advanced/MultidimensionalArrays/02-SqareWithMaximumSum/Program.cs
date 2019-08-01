using System;
using System.Linq;

namespace _02_SqareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = currRow[columns];
                }
            }

            int sum = int.MinValue;
            int rowIndex = 0;
            int columnIndex = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1) -1; columns++)
                {
                    int currSum = matrix[rows, columns]
                        + matrix[rows, columns + 1]
                        + matrix[rows + 1, columns]
                        + matrix[rows + 1, columns + 1];

                    if (currSum > sum)
                    {
                        sum = currSum;
                        rowIndex = rows;
                        columnIndex = columns;
                    }
                } 
            }

            Console.WriteLine(matrix[rowIndex, columnIndex] + " " + matrix[rowIndex, columnIndex + 1]);
            Console.WriteLine(matrix[rowIndex + 1, columnIndex] + " " + matrix[rowIndex + 1, columnIndex + 1]);
            Console.WriteLine(sum);
        }
    }
}
