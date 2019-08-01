using System;
using System.Linq;

namespace _03_SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[rowsAndColumns[0], rowsAndColumns[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] row = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = row[columns];
                }
            }

            int counter = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1) - 1; columns++)
                {
                    char symbol1 = matrix[rows, columns];
                    char symbol2 = matrix[rows, columns + 1];
                    char symbol3 = matrix[rows + 1, columns];
                    char symbol4 = matrix[rows + 1, columns + 1];

                    if (symbol1 == symbol2 && symbol1 == symbol3 && symbol1 == symbol4)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
