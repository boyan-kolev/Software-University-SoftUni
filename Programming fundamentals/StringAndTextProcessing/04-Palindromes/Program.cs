using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach => words
            //reverse only word
            //check isEqual word => revWord
            //add to list all palindromes
            //remove all dublicates
            //sort list
            //printing


            string[] words = Console.ReadLine()
                .Split(",.?! ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            List<string> palindromes = new List<string>();

            foreach (var word in words)
            {
                bool isEquals = IsPalindrome(word);

                if (isEquals)
                {
                    palindromes.Add(word);
                }
            }
            


            palindromes = palindromes
                .OrderBy(x => x)
                .Distinct()
                .ToList();

            Console.WriteLine(string.Join(", ", palindromes));
        }


        static bool IsPalindrome(string word)
        {
            string revWord = new string(word.Reverse().ToArray());
            bool isEquals = string.Equals(revWord, word);

            return isEquals;
        }
    }
}
