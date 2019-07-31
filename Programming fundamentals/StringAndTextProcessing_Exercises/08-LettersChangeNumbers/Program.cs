using System;
using System.Collections.Generic;
using System.Numerics;

namespace _08_LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            decimal totalSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                totalSum += OperationsNumber(input[i]);
            }

            Console.WriteLine("{0:f2}", totalSum);

        }

        static int PositionOfLetters(char letter)
        {
            Dictionary<char, int> alphabetPos = new Dictionary<char, int>();
            int numOfPos = 1;
            for (char i = 'a'; i <= 'z'; i++)
            {
                alphabetPos.Add(i, numOfPos);
                numOfPos++;
            }

            return alphabetPos[letter];
        }

        static decimal OperationsNumber(string word)
        {
            char letter1 = word[0];
            char letter2 = word[word.Length - 1];
            string numAsStr = word.Substring(1, word.Length - 2);

            int number = int.Parse(numAsStr);

            int letter1Pos = PositionOfLetters(char.ToLower(letter1));
            int letter2Pos = PositionOfLetters(char.ToLower(letter2));
            decimal currSum = number;

            if (char.IsLower(letter1))
            {
                currSum *= letter1Pos;
            }
            else
            {
                currSum /= (letter1Pos * 1.0m);
            }

            if (char.IsLower(letter2))
            {
                currSum += letter2Pos;
            }
            else
            {
                currSum -= letter2Pos;
            }

            return currSum;
        }
    }
}
