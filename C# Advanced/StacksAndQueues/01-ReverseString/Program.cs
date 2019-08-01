using System;
using System.Collections.Generic;

namespace _01_ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reverseString = new Stack<char>();

            foreach (char symbol in input)
            {
                reverseString.Push(symbol);
            }

            while (reverseString.Count > 0)
            {
                Console.Write(reverseString.Pop());
            }

            Console.WriteLine();
        }
    }
}
