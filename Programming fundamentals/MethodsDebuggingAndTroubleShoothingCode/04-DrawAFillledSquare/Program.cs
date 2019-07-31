using System;

namespace _04_DrawAFillledSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintFirstAndLastRow(num);
            PrintMiddlePart(num);
            PrintFirstAndLastRow(num);
            
        }

        static void PrintFirstAndLastRow(int number)
        {
            String row = new string('-', number * 2);
            Console.WriteLine(row);
        }

        static void PrintMiddlePart(int number)
        {
            for (int rows = 1; rows <= number - 2 ; rows++)
            {
                Console.Write('-');
                for (int cols = 1; cols < number ; cols++)
                {
                    Console.Write("\\/");
                }
                Console.WriteLine('-');
            }
        }
    }
}
