using System;

namespace p01_RhombusOfStars
{
    class StartUp
    {
        static int sizeOfRhombus;
        static void Main(string[] args)
        {
            sizeOfRhombus = int.Parse(Console.ReadLine());

            for (int counter = 1; counter <= sizeOfRhombus; counter++)
            {
                PrintRow(counter);
            }

            for (int counter = sizeOfRhombus - 1; counter >= 1; counter--)
            {
                PrintRow(counter);
            }
        }

        private static void PrintRow(int countOfStars)
        {
            string space = new string(' ', sizeOfRhombus - countOfStars);
            Console.Write(space);

            for (int counter = 0; counter < countOfStars - 1; counter++)
            {
                Console.Write("* ");
            }

            Console.WriteLine("*");
        }
    }
}
