using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_CountTheUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(letter => char.IsUpper(letter[0]));

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
