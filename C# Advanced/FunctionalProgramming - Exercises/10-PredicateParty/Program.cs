using System;
using System.Collections.Generic;

namespace _10_PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>(Console.ReadLine().Split());

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                string criterion = tokens[1];
                string compareCriterion = tokens[2];

                Func<string, bool> filter = CreateFilter(criterion, compareCriterion);

                for (int counter = 0; counter < names.Count; counter++)
                {
                    if (filter(names[counter]))
                    {
                        switch (command)
                        {
                            case "Remove":
                                names.RemoveAll(x => x == names[counter]);
                                counter--;
                                break;
                            case "Double":
                                names.Insert(counter + 1, names[counter]);
                                counter++;
                                break;
                        }

                    }
                }
            }

            if (names.Count > 0)
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Func<string, bool> CreateFilter(string criterion, string compareCriterion)
        {
            switch (criterion)
            {
                case "StartsWith":
                    return x => x.Substring(0, compareCriterion.Length) == compareCriterion;
                case "EndsWith":
                    return x => x.Substring(x.Length - compareCriterion.Length, compareCriterion.Length) == compareCriterion;
                case "Length":
                    return x => x.Length == int.Parse(compareCriterion);
                default:
                    throw new NotImplementedException();
            }

        }
    }
}
