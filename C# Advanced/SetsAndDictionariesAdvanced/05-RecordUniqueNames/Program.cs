using System;
using System.Collections.Generic;

namespace _05_RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNames = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int counter = 0; counter < numberOfNames; counter++)
            {
                string name = Console.ReadLine();

                names.Add(name);
            }

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
