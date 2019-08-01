using System;
using System.Linq;

namespace _01_SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int coloumns = sizes[1];

            int[,] matrix = new int[rows, coloumns];
            int sum = 0;

            for (int rowsCounter = 0; rowsCounter < matrix.GetLength(0); rowsCounter++)
            {
                int[] currRows = Console.ReadLine()
                        .Split(", ")
                        .Select(int.Parse)
                        .ToArray();

                for (int coloumnsCounter = 0; coloumnsCounter < matrix.GetLength(1); coloumnsCounter++)
                {
                    matrix[rowsCounter, coloumnsCounter] = currRows[coloumnsCounter];
                }
            }

            foreach (int row in matrix)
            {
                sum += row;
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
