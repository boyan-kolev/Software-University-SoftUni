using System;
using System.Collections.Generic;

namespace _03_ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();
                
            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] tokens = input.Split(", ");
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (shops.ContainsKey(shop) == false)
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                if (shops[shop].ContainsKey(product) == false)
                {
                    shops[shop].Add(product, 0);
                }

                shops[shop][product] = price;
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var kvp in shop.Value)
                {
                    Console.WriteLine($"Product: {kvp.Key}, Price: {kvp.Value}");
                }
            }
        }
    }
}
