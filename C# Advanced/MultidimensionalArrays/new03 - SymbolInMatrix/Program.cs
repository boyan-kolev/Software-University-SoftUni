using System;

namespace new03___SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            char[,] matrix = new char[dimensions, dimensions];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] row = Console.ReadLine().ToCharArray();

                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = row[columns];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isExists = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int colummn = 0; colummn < matrix.GetLength(1); colummn++)
                {
                    if (matrix[row, colummn] == symbol)
                    {
                        Console.WriteLine($"({row}, {colummn})");
                        isExists = true;
                        break;
                    }
                }
                if (isExists)
                {
                    break;
                }
            }

            if (isExists == false)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }
        }
    }
}
