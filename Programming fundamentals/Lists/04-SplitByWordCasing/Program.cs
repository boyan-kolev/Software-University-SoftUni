using System;
using System.Collections.Generic;

namespace _04_SplitByWordCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(",;:.!()\"'\\/[] ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            List<string> upperCase = new List<string>();
            List<string> lowerCase = new List<string>();
            List<string> mixedCase = new List<string>();


            for (int i = 0; i < words.Length; i++)
            {
                string curr = words[i];

                if (isLower(curr))
                {
                    lowerCase.Add(curr);
                }
                else if (isUpper(curr))
                {
                    upperCase.Add(curr);
                }
                else
                {
                    mixedCase.Add(curr);
                }
            }

            Console.WriteLine("Lower-case: {0}",string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCase));
            Console.WriteLine("Upper-case: {0}", string.Join(", ", upperCase));

        }


        static bool isLower(string word)
        {
            foreach (char symbol in word)
            {
                if (symbol < 'a' || symbol > 'z')
                {
                    return false;
                }
            }
            return true;
        }

        static bool isUpper(string word)
        {
            foreach (char symbol in word)
            {
                if (symbol < 'A' || symbol > 'Z')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
