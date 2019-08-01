using System;
using System.Collections.Generic;

namespace _11_PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>(Console.ReadLine().Split());
            List<string> filterNames = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] tokens = input.Split(";");
                string command = tokens[0];
                string filterType = tokens[1];
                string filterParameters = tokens[2];

                Func<string, bool> filter = CreateFilter(filterType, filterParameters);

                switch (command)
                {
                    case "Add filter":
                        ForeachNames(names, filterNames, filter);
                        break;
                    case "Remove filter":
                        ForeachNames(filterNames, names, filter);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", names));

        }

        private static void ForeachNames(List<string> names, List<string> filterNames, Func<string, bool> filter)
        {
            for (int counter = 0; counter < names.Count; counter++)
            {
                if (filter(names[counter]))
                {
                    filterNames.Add(names[counter]);
                    names.RemoveAt(counter);
                    counter--;
                }
            }
        }

        static Func<string, bool> CreateFilter(string filterType, string filterParameters)
        {
            switch (filterType)
            {
                case "Starts with":
                    return x => x.StartsWith(filterParameters);
                case "Ends with":
                    return x => x.EndsWith(filterParameters);
                case "Length":
                    return x => x.Length == int.Parse(filterParameters);
                case "Contains":
                    return x => x.Contains(filterParameters);
                default:
                    throw new NotImplementedException();
            }

        }
    }
}
