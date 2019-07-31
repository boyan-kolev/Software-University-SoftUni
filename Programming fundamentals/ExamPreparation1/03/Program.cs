using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> games = new List<string>(Console.ReadLine().Split());

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "Play!")
                {
                    break;
                }

                string command = input[0];
                string game = input[1];

                if (command == "Install")
                {

                    if (games.Contains(game) == false)
                    {
                        games.Add(game);
                    }

                }
                else if (command == "Uninstall")
                {
                    games.Remove(game);
                }
                else if (command == "Update")
                {
                    bool isExist = games.Remove(game);
                    if (isExist)
                    {
                        games.Add(game);
                    }
                }
                else if (command == "Expansion")
                {
                    string[] elements = game.Split("-");
                    int index = games.IndexOf(elements[0]);
                    if (index != -1)
                    {
                        string exp = elements[0] + ":" + elements[1];
                        games.Insert(index + 1, exp);
                    }
                }

            }

            Console.WriteLine(string.Join(" ", games));
        }
    }
}
