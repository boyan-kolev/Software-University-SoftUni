using System;

namespace _15_DebuggingSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int numberCounts = int.Parse(Console.ReadLine());

            bool hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'p')
                {
                    hasMatch = true;

                    int endIndex = numberCounts;

                    if (endIndex > text.Length - i - 1)
                    {
                        endIndex = text.Length - i - 1;
                    }
                    string matchedString = text.Substring(i, endIndex + 1);
                    Console.WriteLine(matchedString);
                    i = i + numberCounts;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}
