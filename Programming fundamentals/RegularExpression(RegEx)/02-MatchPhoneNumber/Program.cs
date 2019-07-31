using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _02_MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string patern = @"\+359( |-)2(\1)\d{3}(\1)\d{4}\,?\b";

            Regex regex = new Regex(patern);

            MatchCollection matches = regex.Matches(input);
            List<Match> phoneNumbers = new List<Match>();

            foreach (Match match in matches)
            {
                phoneNumbers.Add(match);
            }

            Console.WriteLine(string.Join(", ", phoneNumbers));
        }
    }
}
