using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _021
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            string[] songs = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<string>> awards = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] performance = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                if (performance[0] == "dawn")
                {
                    break;
                }

                string participant = performance[0];
                string song = performance[1];
                string award = performance[2];

                if (participants.Contains(participant) && songs.Contains(song))
                {
                    if (awards.ContainsKey(participant) == false)
                    {
                        awards.Add(participant, new List<string>());
                    }

                    if (awards[participant].Contains(award) == false)
                    {
                        awards[participant].Add(award);
                    }
                }

            }

            if (awards.Count == 0)
            {
                Console.WriteLine("No awards");
                return;
            }

            foreach (var award in awards.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {

                Console.WriteLine($"{award.Key}: {award.Value.Count} awards");

                foreach (var participant in award.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"--{participant}");
                }

            }
        }
    }
}
