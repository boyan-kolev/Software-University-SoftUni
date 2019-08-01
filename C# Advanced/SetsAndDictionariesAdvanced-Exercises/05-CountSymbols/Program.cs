using System;
using System.Collections.Generic;

namespace _05_CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            for (int counter = 0; counter < text.Length; counter++)
            {
                if (symbols.ContainsKey(text[counter]) == false)
                {
                    symbols.Add(text[counter], 0);
                }

                symbols[text[counter]]++;
            }

            foreach (var kvp in symbols)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
