using System;
using System.Collections.Generic;

namespace _04_CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfInputLines = int.Parse(Console.ReadLine());

            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int counter = 0; counter < countOfInputLines; counter++)
            {
                string[] input = Console.ReadLine().Split();
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (continents.ContainsKey(continent) == false)
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (continents[continent].ContainsKey(country) == false)
                {
                    continents[continent].Add(country, new List<string>());
                }

                continents[continent][country].Add(city);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine(continent.Key + ":");

                foreach (var kvp in continent.Value)
                {
                    Console.WriteLine($"  {kvp.Key} -> {string.Join(", ", kvp.Value)}");
                }
            }

        }
    }
}
