using System;
using System.Linq;

namespace _05_ShortWordsSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .ToLower()
                .Split(".,:;()[]\"'\\/!? ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);


            words = words.Where(x => x.Length < 5).ToArray();
            words = words.Distinct().OrderBy(x => x).ToArray();

            Console.WriteLine(string.Join(", ", words));
        }
    }
}
