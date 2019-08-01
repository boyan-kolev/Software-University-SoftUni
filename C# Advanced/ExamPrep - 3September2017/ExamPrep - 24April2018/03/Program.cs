using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string ticketPatern = Console.ReadLine();
            string input = Console.ReadLine();

            string patern = @"(\{([^\{\}\[\]]+)?(\[[A-Z]{3} [A-Z]{2}\]([^\{\}\[\]]+)?\[[A-Z]{1}\d{1,2}\])([^\{\}\[\]]+)?\})|(\[([^\{\}\[\]]+)?(\{[A-Z]{3} [A-Z]{2}\}([^\{\}\[\]]+)?\{[A-Z]{1}\d{1,2}\})([^\{\}\[\]]+)?\])";

            MatchCollection matches = Regex.Matches(input, patern);
            List<string> seats = new List<string>();

            foreach (var match in matches)
            {
                string currMatch = match.ToString();
                currMatch = currMatch.Substring(1, currMatch.Length - 2);

                string paternGroup = @"(\[|\{)([A-Z]{3} [A-Z]{2})(\]|\})([^\{\}\[\]]+)?(\{|\[)([A-Z]{1}\d{1,2})(\]|\})";

                Match groups = Regex.Match(currMatch, paternGroup);

                string destination = groups.Groups[2].ToString();
                string numbersOfSeat = groups.Groups[6].ToString();

                if (destination == ticketPatern)
                {
                    seats.Add(numbersOfSeat);
                }

            }

            if (seats.Count > 2)
            {
                string[] duplicateItems = seats.GroupBy(x => x.Substring(1)).Where(x => x.Count() > 1).Select(x => x.Key).ToArray();
                string[] seatsWithSaemRow = seats.Where(x => x.Substring(1) == duplicateItems[0]).ToArray();
                Console.WriteLine($"You are traveling to {ticketPatern} on seats {seatsWithSaemRow[0]} and {seatsWithSaemRow[1]}.");
            }
            else
            {
                Console.WriteLine($"You are traveling to {ticketPatern} on seats {seats[0]} and {seats[1]}.");
            }

        }
    }
}
