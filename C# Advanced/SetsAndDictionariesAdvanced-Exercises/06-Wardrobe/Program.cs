using System;
using System.Collections.Generic;

namespace _06_Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int counterLine = 0; counterLine < lines; counterLine++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];

                if (wardrobe.ContainsKey(color) == false)
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                string[] clothes = input[1].Split(",");

                for (int counterClothes = 0; counterClothes < clothes.Length; counterClothes++)
                {
                    if (wardrobe[color].ContainsKey(clothes[counterClothes]) == false)
                    {
                        wardrobe[color].Add(clothes[counterClothes], 0);
                    }

                    wardrobe[color][clothes[counterClothes]]++;
                }
            }

            string[] choise = Console.ReadLine().Split();
            string chosenColor = choise[0];
            string clothing = choise[1];

            foreach (var kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var pair in kvp.Value)
                {
                    if (kvp.Key == chosenColor && pair.Key == clothing)
                    {
                        Console.WriteLine($"* {pair.Key} - {pair.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {pair.Key} - {pair.Value}");
                    }
                }
            }

        }
    }
}
