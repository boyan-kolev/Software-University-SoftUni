using System;
using System.Collections.Generic;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceBook = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split("|->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);


                if (input == "Lumpawaroo")
                {
                    break;
                }


                if (input.Contains("|"))
                {
                    string forSide = tokens[0].Trim();
                    string forceUser = tokens[1].Trim();

                    if (forceBook.ContainsKey(forSide) == false)
                    {
                        forceBook.Add(forSide, new List<string>());
                    }

                    if (forceBook[forSide].Contains(forceUser) == false)
                    {
                        forceBook[forSide].Add(forceUser);
                    }

                }
                else if (input.Contains("->"))
                {
                    string forceUser = tokens[0].Trim();
                    string forSide = tokens[1].Trim();

                    bool isValid = false;
                    foreach (var item in forceBook)
                    {
                        if (item.Value.Contains(forceUser))
                        {
                            item.Value.Remove(forceUser);
                            isValid = true;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        if (forceBook.ContainsKey(forSide) == false)
                        {
                            forceBook.Add(forSide, new List<string>());
                        }

                        forceBook[forSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forSide} side!");
                    }
                    else
                    {
                        if (forceBook.ContainsKey(forSide) == false)
                        {
                            forceBook.Add(forSide, new List<string>());
                        }

                        forceBook[forSide].Add(forceUser);

                        Console.WriteLine($"{forceUser} joins the {forSide} side!");
                    }
                }
            }

            foreach (var kvp in forceBook.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (kvp.Value.Count != 0)
                {

                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                    foreach (var forceSide in kvp.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {forceSide}");
                    }
                }
            }
        }
    }
}
