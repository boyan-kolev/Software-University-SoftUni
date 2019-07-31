using System;
using System.Linq;

namespace _05_CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] letters1 = Console.ReadLine()
                .Split()
                .Select(letter => char.Parse(letter))
                .ToArray();

            char[] letters2 = Console.ReadLine()
                .Split()
                .Select(letter => char.Parse(letter))
                .ToArray();

            int minLength = Math.Min(letters1.Length, letters2.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (letters1[i] < letters2[i])
                {
                    Console.WriteLine(string.Join("", letters1));
                    Console.WriteLine(string.Join("", letters2));
                    return;
                }
                else if (letters1[i] > letters2[i])
                {
                    Console.WriteLine(string.Join("", letters2));
                    Console.WriteLine(string.Join("", letters1));
                    return;
                }

            }
            if (letters1.Length > letters2.Length)
            {
                Console.WriteLine(string.Join("", letters2));
                Console.WriteLine(string.Join("", letters1));
                return;
            }
            else if (letters2.Length > letters1.Length)
            {
                Console.WriteLine(string.Join("", letters1));
                Console.WriteLine(string.Join("", letters2));
                return;
            }

            Console.WriteLine(string.Join("", letters1));
            Console.WriteLine(string.Join("", letters2));
        }
    }
}
