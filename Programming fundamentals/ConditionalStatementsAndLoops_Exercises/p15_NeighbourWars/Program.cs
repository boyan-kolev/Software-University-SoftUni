using System;

namespace p15_NeighbourWars
{
    class Program
    {
        static void Main(string[] args)
        {
            int peshoDamage = int.Parse(Console.ReadLine());
            int goshoDamage = int.Parse(Console.ReadLine());
            int peshoHealth = 100;
            int goshoHealth = 100;
            int turn = 1;


            while (true)
            {
                if (turn % 2 == 0)
                {
                    if (peshoHealth - goshoDamage <= 0)
                    {
                        Console.WriteLine($"Gosho won in {turn}th round.");
                        break;
                    }
                    else
                    {
                        peshoHealth = peshoHealth - goshoDamage;
                        Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {peshoHealth} health.");
                    }
                }
                else
                {
                    if (goshoHealth - peshoDamage <= 0)
                    {
                        Console.WriteLine($"Pesho won in {turn}th round.");
                        break;
                    }
                    else
                    {                
                        goshoHealth = goshoHealth - peshoDamage;
                        Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {goshoHealth} health.");
                    }
                }

                if (turn % 3 == 0)
                {
                    peshoHealth += 10;
                    goshoHealth += 10;
                }
                turn++;
            }
        }
    }
}


