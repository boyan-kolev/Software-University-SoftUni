using System;
using System.Linq;

namespace _04_FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();
            var filter = CreateFilter(command);
            Action<int> printNumber = x => Console.Write(x + " ");

            for (int counter = range[0]; counter <= range[1]; counter++)
            {
                if (filter(Math.Abs(counter)))
                {
                    printNumber(counter);
                }
            }
            Console.WriteLine();

        }

        static Func<int ,bool> CreateFilter(string command)
        {
            switch (command)
            {
                case "even":
                    return x => x % 2 == 0;
                case "odd":
                    return x => x % 2 == 1;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
