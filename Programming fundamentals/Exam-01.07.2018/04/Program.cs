using System;
using System.Linq;
using System.Collections.Generic;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> results = new Dictionary<string, int>();
            Dictionary<string, int> submisions = new Dictionary<string, int>();

            while (true)
            {
                string inputt = Console.ReadLine();

                if (inputt == "exam finished")
                {
                    break;
                }
                string[] input = inputt.Split("-");

                if (input[1] == "banned")
                {
                    string name = input[0];
                    results.Remove(name);
                }
                else
                {
                    string username = input[0];
                    string language = input[1];
                    int points = int.Parse(input[2]);

                    if (results.ContainsKey(username) == false)
                    {
                        results.Add(username, 0);
                    }

                    results[username] = points;

                    if (submisions.ContainsKey(language) == false)
                    {
                        submisions.Add(language, 0);
                    }

                    submisions[language]++;
                }

            }



            Console.WriteLine($"Results:");
            foreach (var result in results.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{result.Key} | {result.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var sumbision in submisions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{sumbision.Key} - {sumbision.Value}");
            }
        }
    }
}
