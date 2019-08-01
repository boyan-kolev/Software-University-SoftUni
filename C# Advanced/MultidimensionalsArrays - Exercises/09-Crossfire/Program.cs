using System;
using System.Collections.Generic;

namespace _09_Crossfire
{
    class Program
    {
        static long rows;
        static long columns;
        static List<List<long>> matrix;
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split();
            rows = long.Parse(dimensions[0]);
            columns = long.Parse(dimensions[1]);

            matrix = new List<List<long>>();
            matrix = FillMatrix();

            while (true)
            {
                string input = Console.ReadLine().Trim();

                if (input == "Nuke it from orbit")
                {
                    break;
                }

                string[] tokens = input.Split();
                int fireRow = int.Parse(tokens[0]);
                int fireColumn = int.Parse(tokens[1]);
                int radius = int.Parse(tokens[2]);

                DestructionRowAndColumns(fireRow, fireColumn, radius);
            }

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int column = 0; column < matrix[row].Count; column++)
                {
                    Console.Write(matrix[row][column] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void DestructionRowAndColumns(int fireRow, int fireColumn, int radius)
        {

            int startIndexColumn = Math.Max((fireColumn - radius), 0);
            int endIndexColummn = Math.Min((fireColumn + radius), matrix[fireRow].Count - 1);

            for (int column = startIndexColumn; column <= endIndexColummn; column++)
            {
                matrix[fireRow].RemoveAt(startIndexColumn);
            }

            int startIndexRow = Math.Max((fireRow - radius), 0);
            int endIndexRow = Math.Min((fireRow + radius), matrix.Count - 1);

            for (int row = startIndexRow; row <= endIndexRow; row++)
            {
                if (matrix[row].Count - 1 < fireColumn)
                {
                    continue;
                }
                else
                {

                    matrix[row].RemoveAt(fireColumn);
                }

            }

           


        }



        private static List<List<long>> FillMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<long>());
                for (int column = 0; column < columns; column++)
                {
                    matrix[row].Add((row * columns) + (column + 1));
                }
            }


            return matrix;
        }
    }
}
