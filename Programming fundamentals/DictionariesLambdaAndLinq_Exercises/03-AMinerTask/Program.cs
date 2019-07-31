using System;
using System.Collections.Generic;

namespace _03_AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> quantityOfResource = new Dictionary<string, int>();
            string resource = input;

            while ((input == "stop") == false)
            {
                if (int.TryParse(input, out int result) == false)
                {
                    resource = input;
                    if (quantityOfResource.ContainsKey(input) == false)
                    {
                        quantityOfResource.Add(input, 0);
                    }
                }
                else
                {
                    int quantity = int.Parse(input);
                    quantityOfResource[resource] += quantity;
                }

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, int> kvp in quantityOfResource)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
