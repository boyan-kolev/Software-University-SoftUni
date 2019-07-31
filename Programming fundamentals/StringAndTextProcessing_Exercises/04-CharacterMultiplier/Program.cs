using System;

namespace _04_CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string firstWord = input[0];
            string secondWord = input[1];

            int sumOfMultiplierChars = MultiplierChars(firstWord, secondWord);

            Console.WriteLine(sumOfMultiplierChars);

        }
        static int MultiplierChars(string word1, string word2)
        {
            int minLength = Math.Min(word1.Length, word2.Length);

            int sum = 0;
            for (int i = 0; i < minLength; i++)
            {
                char firstChar = word1[i];
                char secondChar = word2[i];

                sum += (int)firstChar * (int)secondChar;
            }

            if (word1.Length > minLength)
            {
                for (int i = word1.Length - 1; i >= word2.Length; i--)
                {
                    char remainigChar = word1[i];
                    sum += (int)remainigChar;
                }
            }
            else if (word2.Length > minLength)
            {
                for (int i = word2.Length - 1; i >= word1.Length; i--)
                {
                    char remainingChar = word2[i];
                    sum += (int)remainingChar;
                }

            }

            return sum;
        } 
    }
}
