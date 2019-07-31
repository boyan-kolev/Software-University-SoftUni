using System;

namespace _01_LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] words1 = Console.ReadLine()
                .Split(' ');
            String[] words2 = Console.ReadLine()
                .Split(' ');

            int minLength = Math.Min(words1.Length, words2.Length);
            int counterLeft = 0;
            int counterRight = 0;

            for (int i = 0; i < minLength; i++)
            {
                if (words1[i] == words2[i])
                {
                    counterLeft++;
                }

                if (words1[words1.Length - 1 - i] == words2[words2.Length - 1 - i])
                {
                    counterRight++;
                }
            }

            int maxCount = Math.Max(counterLeft, counterRight);
            Console.WriteLine(maxCount);
        }
    }
}
