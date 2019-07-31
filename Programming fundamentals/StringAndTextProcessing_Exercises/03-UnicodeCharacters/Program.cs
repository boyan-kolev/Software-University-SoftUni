using System;
using System.Text;

namespace _03_UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder unicode = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                unicode = unicode.Append("\\u" + ((int)input[i]).ToString("x4"));
            }

            Console.WriteLine(unicode);
        }
    }
}
