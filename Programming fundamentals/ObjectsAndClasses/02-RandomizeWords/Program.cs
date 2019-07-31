using System;

namespace _02_RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int index = rnd.Next(0, words.Length);
                string curr = words[i];
                words[i] = words[index];
                words[index] = curr;
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
