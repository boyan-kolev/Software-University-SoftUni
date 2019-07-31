using System;
using System.Collections.Generic;
using System.Linq;

namespace _01CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> realNums = Console.ReadLine()
                .Split()
                .Select(x => double.Parse(x))
                .ToList();

            SortedDictionary<double, int> countOfNums = new SortedDictionary<double, int>();

            for (int i = 0; i < realNums.Count; i++)
            {
                if (countOfNums.ContainsKey(realNums[i]) == false)
                {
                    countOfNums.Add(realNums[i], 0);
                }
                countOfNums[realNums[i]]++;
            }

            foreach (KeyValuePair<double, int> kvp in countOfNums)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
