using System;

namespace _04_PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            long[][] triangle = new long[height][];

            for (int rows = 0; rows < triangle.Length; rows++)
            {
                triangle[rows] = new long[rows + 1];
            }

            for (int rows = 0; rows < triangle.Length; rows++)
            {
                triangle[rows][0] = 1;
                triangle[rows][rows] = 1;

                if (rows >= 2)
                {
                    for (int columns = 1; columns < rows; columns++)
                    {
                        triangle[rows][columns] = triangle[rows - 1][columns - 1] + triangle[rows - 1][columns];
                    }
                }
            }

            for (int rows = 0; rows < triangle.Length; rows++)
            {
                for (int columns = 0; columns < triangle[rows].Length; columns++)
                {
                    Console.Write(triangle[rows][columns] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
