using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            string name;
            bool isParty = false;

            while ((name = Console.ReadLine()) != "END")
            {
                if (name == "PARTY")
                {
                    isParty = true;
                }

                if (isParty)
                {
                    names.Remove(name);
                }
                else
                {
                    names.Add(name);
                }
            }

            Console.WriteLine(names.Count);

            foreach (var item in names.Where(x => int.TryParse(x[0].ToString(), out int n)))
            {
                Console.WriteLine(item);
            }

            foreach (var item in names.Where(x => int.TryParse(x[0].ToString(), out int n) == false))
            {
                Console.WriteLine(item);
            }
        }
    }
}
