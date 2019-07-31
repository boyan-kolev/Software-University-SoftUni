using System;

namespace _03_PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            PrintTriangle(num);
        }

        static void PrintTriangle(int number)
        {
            PrintHeader(number);
            PrintMiddlePart(number);
            PrintFooter(number);


        }

        static void PrintHeader(int number)
        {
            for (int rows = 1; rows < number; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    Console.Write(cols + " ");
                }
                Console.WriteLine();

            }
        }

        static void PrintMiddlePart(int number)
        {
            for (int currNum = 1; currNum <= number; currNum++)
            {
                Console.Write(currNum + " ");
            }
            Console.WriteLine();
        }

        static void PrintFooter(int number)
        {
            for (int rows = 1; rows <= number; rows++)
            {
                int count = 1;
                for (int cols = number - 1; cols >= rows; cols--)
                {
                    Console.Write(count + " ");
                    count++;
                }
                Console.WriteLine();
            }
        }
    }
}
