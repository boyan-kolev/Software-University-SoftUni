using System;

namespace _02_KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nameOfKnights = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string> printKnight = name => Console.WriteLine($"Sir {name}");
            foreach (string name in nameOfKnights)
            {
                printKnight(name);
            }
        }
    }
}
