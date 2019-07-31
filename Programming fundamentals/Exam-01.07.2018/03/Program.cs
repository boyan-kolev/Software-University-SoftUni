using System;
using System.Text.RegularExpressions;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalSum = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of shift")
                {
                    break;
                }

                string paternName = @"%([A-Z][a-z]+)%";
                string paternProduct = @"<(.+)>";
                string paternCount = @"\|(\d+)\|";
                string paternPrice = @"(-?\d+.?\d+)\$";

                Regex regex1 = new Regex(paternName);
                Match match1 = regex1.Match(input);

                Regex regex2 = new Regex(paternProduct);
                Match match2 = regex2.Match(input);

                Regex regex3 = new Regex(paternCount);
                Match match3 = regex3.Match(input);

                Regex regex4 = new Regex(paternPrice);
                Match match4 = regex4.Match(input);

                if (match1.Success && match2.Success && match3.Success && match4.Success)
                {
                    string name = string.Empty;
                    string product = string.Empty;
                    string count = string.Empty;
                    string price = string.Empty;

                    MatchCollection matches1 = regex1.Matches(input);
                    foreach (Match match11 in matches1)
                    {
                        name = match11.Groups[1].ToString();
                    }

                    MatchCollection matches2 = regex2.Matches(input);
                    foreach (Match match22 in matches2)
                    {
                        product = match22.Groups[1].ToString();
                    }

                    MatchCollection matches3 = regex3.Matches(input);
                    foreach (Match match33 in matches3)
                    {
                        count = match33.Groups[1].ToString();
                    }

                    MatchCollection matches4 = regex4.Matches(input);
                    foreach (Match match44 in matches4)
                    {
                        price = match44.Groups[1].ToString();
                    }


                    int count1 = int.Parse(count);
                    double price1 = double.Parse(price);
                    double sum = count1 * price1;

                    totalSum += sum;

                    Console.WriteLine($"{name}: {product} - {sum:f2}");
                }

            }

            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}
