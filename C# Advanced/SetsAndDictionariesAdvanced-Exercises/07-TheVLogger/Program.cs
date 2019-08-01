using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vloggersFollowed = new Dictionary<string, List<string>>();
            var countFollowed = new Dictionary<string, List<int>>();


            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input.Split();
                if (tokens[1] == "joined")
                {
                    if (vloggersFollowed.ContainsKey(tokens[0]) == false)
                    {
                        vloggersFollowed.Add(tokens[0], new List<string>());
                        countFollowed.Add(tokens[0], new List<int>(2));
                        countFollowed[tokens[0]].Add(0);
                        countFollowed[tokens[0]].Add(0);

                    }
                }
                else if (tokens[1] == "followed")
                {
                    if (tokens[0] == tokens[2])
                    {
                        continue;
                    }
                    else if (vloggersFollowed.ContainsKey(tokens[0]) && vloggersFollowed.ContainsKey(tokens[2]))
                    {
                        if (vloggersFollowed[tokens[2]].Contains(tokens[0]) == false)
                        {
                            vloggersFollowed[tokens[2]].Add(tokens[0]);
                            countFollowed[tokens[0]][1]++;
                            countFollowed[tokens[2]][0]++;
                        }
                    }
                }
            }

            var mostFamous = countFollowed.OrderBy(x => x.Value[1]).ThenByDescending(y => y.Value[0]).FirstOrDefault();

            Console.WriteLine($"The V-Logger has a total of {vloggersFollowed.Count} vloggers in its logs.");
            Console.WriteLine($"1. {mostFamous.Key} : {mostFamous.Value[0]} followers, {mostFamous.Value[1]} following");

            string[] mostFollowers = vloggersFollowed[mostFamous.Key].OrderBy(x => x).ToArray();

            foreach (string followers in mostFollowers)
            {
                Console.WriteLine($"*  {followers}");
            }

            int counter = 2;

            foreach (var kvp in countFollowed.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Value[1]))
            {
                if (kvp.Key == mostFamous.Key)
                {
                    continue;
                }

                Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value[0]} followers, {kvp.Value[1]} following");
                counter++;
            }

        }
    }
}
