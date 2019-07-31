using System;
using System.Collections.Generic;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> players = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string str = Console.ReadLine();
                if (str == "Season end")
                {
                    break;
                }
                string[] input = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[1] == "->")
                {
                    string player = input[0];
                    string position = input[2];
                    long skill = long.Parse(input[4]);

                    if (players.ContainsKey(player) == false)
                    {
                        players.Add(player, new Dictionary<string, long>());
                    }

                    if (players[player].ContainsKey(position) == false)
                    {
                        players[player].Add(position, 0);
                    }

                    if (players[player][position] < skill)
                    {
                        players[player][position] = skill;
                    }


                }
                else if (input[1] == "vs")
                {
                    string player1 = input[0];
                    string player2 = input[2];

                    if ((players.ContainsKey(player1) && players.ContainsKey(player2)))
                    {
                        bool isTrashes = false;
                        foreach (var position1 in players[player1])
                        {
                            if (isTrashes)
                            {
                                break;
                            }
                            foreach (var position2 in players[player2])
                            {
                                if (isTrashes)
                                {
                                    break;
                                }
                                if (position1.Key == position2.Key)
                                {
                                    if (position1.Value > position2.Value)
                                    {
                                        players.Remove(player2);
                                        isTrashes = true;
                                    }

                                    if (position1.Value < position2.Value)
                                    {
                                        players.Remove(player1);
                                        isTrashes = true;
                                    }
                                }
                            }
                        }
                    }

                }
            }


            players = players.OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, y => y.Value);



            foreach (var player in players)
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var position in player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }
    }
}
