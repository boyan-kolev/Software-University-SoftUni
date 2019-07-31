using System;
using System.Text.RegularExpressions;

namespace _01_MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();
            string patern = @"\b[A-Z][a-z]+\s[A-Z][a-z]+\b";

            Regex regex = new Regex(patern);

            MatchCollection matches = regex.Matches(names);

            foreach (Match match in matches)
            {
                Console.Write(match + " ");
            }

            Console.WriteLine();
        }
    }
}
