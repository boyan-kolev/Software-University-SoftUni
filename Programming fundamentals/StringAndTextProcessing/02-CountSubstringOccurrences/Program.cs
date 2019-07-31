using System;
using System.Linq;

namespace _02_CountSubstringOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string searchWord = Console.ReadLine().ToLower();
            int count = 0;

            for (int i = 0; i <= text.Length - searchWord.Length; i++)
            {

                char [] symbols = text.Skip(i)
                    .Take(searchWord.Length).ToArray();

                string subString = new string(symbols);

                bool isEqual = string.Equals(subString, searchWord);

                if (isEqual)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
