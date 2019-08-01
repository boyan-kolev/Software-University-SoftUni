using System;
using System.Linq;

namespace new04___JagedArrayModificaton
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            int[,] matrix = new int[dimensions, dimensions];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = currRow[column];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split();
                string commandType = tokens[0];
                int row = int.Parse(tokens[1]);
                int column = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                bool isValidCoordinates = row >= 0 && row < matrix.GetLength(0) &&
                    column >= 0 && column < matrix.GetLength(1);

                if (isValidCoordinates)
                {
                    switch (commandType)
                    {
                        case "Add":
                            matrix[row, column] += value;
                            break;
                        case "Subtract":
                            matrix[row, column] -= value;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row, column] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
