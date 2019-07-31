using System;
using System.Linq;
using System.Text;

namespace _01_ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char[] symbols = text.ToCharArray();

            StringBuilder reverseText = new StringBuilder();

            for (int i = symbols.Length - 1; i >= 0; i--)
            {
                reverseText = reverseText.Append(symbols[i]);
            }

            Console.WriteLine(reverseText);
        }
    }
}
