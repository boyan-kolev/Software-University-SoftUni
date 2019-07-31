using System;
using System.Linq;
using System.Collections.Generic;

namespace _09_LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);

            SortedDictionary<string, int> junkMaterials = new SortedDictionary<string, int>();
            bool flag = true;
            string obtainedEl = string.Empty;

            while (flag)
            {
                string[] input = Console.ReadLine().ToLower().Split();

                for (int i = 0; i < input.Length - 1; i+=2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1];

                    switch (material)
                    {
                        case "shards":
                            keyMaterials["shards"] += quantity;
                            break;
                        case "fragments":
                            keyMaterials["fragments"] += quantity;
                            break;
                        case "motes":
                            keyMaterials["motes"] += quantity;
                            break;

                        default:
                            if (junkMaterials.ContainsKey(material) == false)
                            {
                                junkMaterials.Add(material, 0);
                            }

                            junkMaterials[material] += quantity;
                            break;
                    }
                    
                    if (keyMaterials["shards"] >= 250)
                    {
                        keyMaterials["shards"] -= 250;
                        obtainedEl = "Shadowmourne obtained!";
                        flag = false;
                        break;
                    }
                    else if (keyMaterials["fragments"] >= 250)
                    {
                        keyMaterials["fragments"] -= 250;
                        obtainedEl = "Valanyr obtained!";
                        flag = false;
                        break;
                    }
                    else if (keyMaterials["motes"] >= 250)
                    {
                        keyMaterials["motes"] -= 250;
                        obtainedEl = "Dragonwrath obtained!";
                        flag = false;
                        break;
                    }
                }
            }

            keyMaterials = keyMaterials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key ,y => y.Value);

            Console.WriteLine(obtainedEl);

            foreach (var material in keyMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            foreach (var material in junkMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
