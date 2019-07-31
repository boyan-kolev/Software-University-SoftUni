using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_handsOfCard
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(":");

                if (input[0] == "JOKER")
                {
                    break;
                }

                string player = input[0];
                string[] cards = input[1]
                    .Trim()
                    .Split(", ");

                if (players.ContainsKey(player) == false)
                {
                    players.Add(player, new List<string>());
                }

                players[player].AddRange(cards);
            }

            Dictionary<string, int> powers = new Dictionary<string, int>();

            for (int i = 2; i <= 9; i++)
            {
                powers.Add(i.ToString(), i);
            }

            powers.Add("1", 10);
            powers.Add("J", 11);
            powers.Add("Q", 12);
            powers.Add("K", 13);
            powers.Add("A", 14);

            powers.Add("S", 4);
            powers.Add("H", 3);
            powers.Add("D", 2);
            powers.Add("C", 1);

            foreach (KeyValuePair<string, List<string>> player in players)
            {
                List<string> cards = player
                    .Value
                    .Distinct()
                    .ToList();
                int sum = 0;
                foreach (string card in cards)
                {
                    string cardPowerStr = card[0].ToString();
                    string cardSuitStr = card[card.Length - 1].ToString();

                    int cardPower = powers[cardPowerStr];
                    int cardSuit = powers[cardSuitStr];

                    sum += cardPower * cardSuit;
                }

                Console.WriteLine($"{player.Key}: {sum}");
            }
        }
    }
}
