using System;

namespace _03_PrintingTriangle2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int cols = 1; cols < number; cols++)
            {
                PrintLine(1, cols);
            }

            PrintLine(1, number);

            for (int cols = number - 1; cols >= 1; cols--)
            {
                PrintLine(1, cols);
            }

        }

        static void PrintLine(int start ,int end)
        {
            for (int row = start; row <= end; row++)
            {
                Console.Write(row + " ");
            }
            Console.WriteLine();
        }
    }
}
