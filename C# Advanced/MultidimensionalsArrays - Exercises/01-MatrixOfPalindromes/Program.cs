using System;
using System.Linq;

namespace _01_MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            char[] alphabet = new char[26];
            for (int index = 0; index < 26; index++)
            {
                alphabet[index] = (char)(97 + index);
            }

            string[,] matrix = new string[rowsAndColumns[0], rowsAndColumns[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] =
                        alphabet[rows].ToString() +
                        alphabet[rows + columns] +
                        alphabet[rows].ToString();
                }
            }


            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    Console.Write(matrix[rows, columns] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
