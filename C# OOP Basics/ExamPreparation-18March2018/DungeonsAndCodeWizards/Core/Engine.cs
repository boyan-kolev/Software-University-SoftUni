using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                string[] inputArgs = input.Split();

                string command = inputArgs[0];

                string result = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            result = dungeonMaster.JoinParty(inputArgs);
                            break;
                        case "AddItemToPool":
                            result = dungeonMaster.AddItemToPool(inputArgs);
                            break;
                        case "PickUpItem":
                            result = dungeonMaster.PickUpItem(inputArgs);
                            break;
                        case "UseItem":
                            result = dungeonMaster.UseItem(inputArgs);
                            break;
                        case "UseItemOn":
                            result = dungeonMaster.UseItemOn(inputArgs);
                            break;
                        case "GiveCharacterItem":
                            result = dungeonMaster.GiveCharacterItem(inputArgs);
                            break;
                        case "GetStats":
                            result = dungeonMaster.GetStats();
                            break;
                        case "Attack":
                            result = dungeonMaster.Attack(inputArgs);
                            break;
                        case "Heal":
                            result = dungeonMaster.Heal(inputArgs);
                            break;
                        case "EndTurn":
                            result = dungeonMaster.EndTurn(inputArgs);
                            break;
                        case "IsGameOver":
                            dungeonMaster.IsGameOver();
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Invalid Operation: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Parameter Error: " + ex.Message);
                }

                if (dungeonMaster.IsGameOver())
                {
                    break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(dungeonMaster.GetStats());
        }
    }
}
