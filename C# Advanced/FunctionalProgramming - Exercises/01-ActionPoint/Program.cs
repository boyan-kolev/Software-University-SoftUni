using System;

namespace _01_ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Action<string> print = (name) => Console.WriteLine(name);

            foreach (string name in names)
            {
                print(name);
            }
        }
    }
}
