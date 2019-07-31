using System;
using System.Collections.Generic;

namespace _02_OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().ToLower().Split();

            Dictionary<string, int> countOfWord = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (countOfWord.ContainsKey(words[i]) == false) 
                {
                    countOfWord.Add(words[i], 0);
                }
                countOfWord[words[i]]++;
            }

            List<string> oddWords = new List<string>();

            foreach (KeyValuePair<string, int> kvp in countOfWord)
            {
                if ((kvp.Value % 2 == 0) == false)
                {
                    oddWords.Add(kvp.Key);
                }
            }

            Console.WriteLine(string.Join(", ", oddWords));
        }
    }
}
