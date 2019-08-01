using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_InfernoIII
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> gems = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var filters = new Dictionary<string, Func<List<int>, List<int>>>();

            string input;
            while ((input = Console.ReadLine()) != "Forge")
            {
                ParseCommand(input, filters);
            }

            List<int> filtered = GetFiltered(filters, gems);

            gems = gems.Where(x => !filtered.Contains(x)).ToList();

            Console.WriteLine(string.Join(" ", gems));

        }

        private static List<int> GetFiltered(Dictionary<string, Func<List<int>, List<int>>> filters, List<int> gems)
        {
            List<int> filtered = new List<int>();

            foreach (var pair in filters)
            {
                var filter = pair.Value;
                filtered.AddRange(filter(gems));
            }

            return filtered;
        }

        private static void ParseCommand(string input, Dictionary<string, Func<List<int>, List<int>>> filters)
        {
            string[] tokens = input.Split(";");
            string command = tokens[0];
            string filterType = tokens[1];
            int filterParameter = int.Parse(tokens[2]);
            string dictKey = $"{filterType} {filterParameter}";

            switch (command)
            {
                case "Exclude":
                    filters[dictKey] = CreateFunction(filterType, filterParameter);
                    break;
                case "Reverse":
                    filters.Remove(dictKey);
                    break;
            }

        }

        private static Func<List<int>, List<int>> CreateFunction(string filterType, int filterParameter)
        {
            switch (filterType)
            {
                case "Sum Left":
                    return gems => gems.Where(gem => 
                    {
                        int index = gems.IndexOf(gem);
                        int leftSum = index > 0 ? gems[index - 1] : 0;
                        return (leftSum + gem) == filterParameter;
                    }).ToList();
                case "Sum Right":
                    return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int RightSum = index < gems.Count - 1 ? gems[index + 1] : 0;
                        return RightSum + gem == filterParameter;
                    }).ToList();
                case "Sum Left Right":
                    return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int leftSum = index > 0 ? gems[index - 1] : 0;
                        int RightSum = index < gems.Count - 1 ? gems[index + 1] : 0;
                        return (leftSum + gem + RightSum) == filterParameter;
                    }).ToList();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
