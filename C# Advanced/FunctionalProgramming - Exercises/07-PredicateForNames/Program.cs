using System;
using System.Linq;

namespace _07_PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLenght = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, bool> filterName = x => x.Length <= nameLenght;

            string[] remainingNames = names.Where(filterName).ToArray();

            Action<string> printName = x => Console.WriteLine(x);

            foreach (string name in remainingNames)
            {
                printName(name);
            }
        }
    }
}
