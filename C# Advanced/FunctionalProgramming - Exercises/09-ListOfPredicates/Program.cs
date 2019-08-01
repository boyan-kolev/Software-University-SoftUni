using System;
using System.Linq;

namespace _09_ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, bool>[] predicates = numbers.Select(div => (Func<int, bool>)(x => x % div == 0)).ToArray();

            for (int counter = 1; counter <= endNumber; counter++)
            {
                bool isDivisable = true;

                foreach (Func<int, bool> predicate in predicates)
                {
                    if (predicate(counter) == false)
                    {
                        isDivisable = false;
                        break;
                    }
                }

                if (isDivisable)
                {
                    Console.Write(counter + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
