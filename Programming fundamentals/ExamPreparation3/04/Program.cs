using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tickets.Length; i++)
            {
                tickets[i] = tickets[i].Trim();
                if (tickets[i].Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string leftPart = tickets[i].Substring(0, 10);
                string rightPart = tickets[i].Substring(10, 10);
                string patern = @"(@{6,10})|(#{6,10})|(\${6,10})|(\^{6,10})";

                Regex regex = new Regex(patern);

                MatchCollection matches1 = regex.Matches(leftPart);
                MatchCollection matches2 = regex.Matches(leftPart);

                Match match1 = regex.Match(leftPart);
                Match match2 = regex.Match(rightPart);

                if (match1.Success && match2.Success)
                {
                    if (match1.Value == match2.Value)
                    {
                        string symbol = match1.Value[0].ToString();

                        if (match1.Length == 10)
                        {
                            Console.WriteLine($"ticket \"{tickets[i]}\" - {match1.Length}{symbol} Jackpot!");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{tickets[i]}\" - {match1.Length}{symbol}");
                        }
                    }

                }
                else
                {
                    Console.WriteLine($"ticket \"{tickets[i]}\" - no match");
                }

            }
        }
    }
}
