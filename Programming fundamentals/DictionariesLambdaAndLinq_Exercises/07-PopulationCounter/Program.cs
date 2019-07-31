using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var countries = new Dictionary<string, Dictionary<string, int>>();
            var countryPopulation = new Dictionary<string, int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split("|");

                if (input[0] == "report")
                {
                    break;
                }

                string country = input[1];
                string city = input[0];
                int population = int.Parse(input[2]);

                if (countries.ContainsKey(country) == false)
                {
                    countries.Add(country, new Dictionary<string, int>());
                }

                if (countries[country].ContainsKey(city) == false)
                {
                    countries[country].Add(city, 0);
                }

                countries[country][city] += population;


                if (countryPopulation.ContainsKey(country) == false)
                {
                    countryPopulation.Add(country, 0);
                }

                countryPopulation[country] += population;
            }


            countryPopulation = countryPopulation
                .OrderByDescending(country => country.Value)
                .ToDictionary(country => country.Key , popul => popul.Value);

            foreach (var country in countryPopulation)
            {
                string countryStr = country.Key.ToString();
                countries[countryStr] = countries[countryStr]
                    .OrderByDescending(city => city.Value)
                    .ToDictionary(city => city.Key, popul => popul.Value);

                Console.WriteLine($"{countryStr} (total population: {country.Value})");

                foreach (var kvp in countries[countryStr])
                {
                    Console.WriteLine($"=>{kvp.Key}: {kvp.Value}");
                }
            }
        }
    }
}
