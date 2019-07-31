using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _041
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(',');

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

                if ((match1.Success && match2.Success) && (match1.Value[0] == match2.Value[0]))
                {
                    int minCount = Math.Min(match1.Length, match2.Length);
                    string symbol = match1.Value[0].ToString();
                    int length = 0;

                    if (minCount == match1.Length)
                    {
                        length = match1.Length;
                    }
                    else
                    {
                        length = match2.Length;

                    }

                    if (match1.Length == 10)
                    {
                        Console.WriteLine($"ticket \"{tickets[i]}\" - {length}{symbol} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{tickets[i]}\" - {length}{symbol}");
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
