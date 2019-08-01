using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {

            string likeJenre = Console.ReadLine();
            string likeDuration = Console.ReadLine();
            Dictionary<string, TimeSpan> movies = new Dictionary<string, TimeSpan>();
            TimeSpan totalDuration = TimeSpan.ParseExact("00:00:00", "hh\\:mm\\:ss", CultureInfo.InvariantCulture);

            string input;
            while ((input = Console.ReadLine()) != "POPCORN!")
            {
                string[] tokens = input.Split("|");
                string movie = tokens[0];
                string jenre = tokens[1];
                TimeSpan duration = TimeSpan.ParseExact(tokens[2], "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
                totalDuration += duration;

                if (jenre == likeJenre)
                {
                    if (movies.ContainsKey(movie) == false)
                    {
                        movies.Add(movie, duration);
                    }
                }

            }

            if (likeDuration == "Short")
            {
                foreach (var kvp in movies.OrderBy(x => x.Value).ThenBy(x => x.Key))
                {
                    string command = Console.ReadLine();
                    Console.WriteLine(kvp.Key);
                    if (command == "Yes")
                    {
                        Console.WriteLine($"We're watching {kvp.Key} - {kvp.Value}");
                        break;
                    }

                }
            }
            else if (likeDuration == "Long")
            {
                foreach (var kvp in movies.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    string command = Console.ReadLine();
                    Console.WriteLine(kvp.Key);
                    if (command == "Yes")
                    {
                        Console.WriteLine($"We're watching {kvp.Key} - {kvp.Value}");
                        break;
                    }
                }
            }


            Console.WriteLine($"Total Playlist Duration: {totalDuration}");
        }
    }
}
