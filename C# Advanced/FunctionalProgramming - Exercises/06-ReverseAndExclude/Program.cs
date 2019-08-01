using System;
using System.Linq;

namespace _06_ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            int devider = int.Parse(Console.ReadLine());

            var filter = CreateFilter(devider);

            foreach (int number in numbers)
            {
                if (filter(number))
                {
                    Console.Write(number + " ");
                }
            }


        }

        static Func<int, bool> CreateFilter(int devider)
        {
            return x => x % devider != 0;
        }
    }
}
