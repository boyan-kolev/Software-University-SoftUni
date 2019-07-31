using System;
using System.Linq;

namespace _09_IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            char[] word = Console.ReadLine().ToCharArray();

            foreach (char letter in word)
            {
                int index = IndexOf(alpha, letter);
                Console.WriteLine($"{letter} -> {index}");

            }

        }

        static int IndexOf(char[] alphabet, char letters)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (alphabet[i] == letters)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
