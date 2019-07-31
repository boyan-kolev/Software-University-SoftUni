using System;

namespace p05_ForeignLanguages
{
    class Program
    {
        static void Main(string[] args)
        {
            String countryName = Console.ReadLine();
            switch (countryName)
            {
                case "England":
                case "USA":
                    Console.WriteLine("English");
                    break;
                case "Spain":
                case "Argentina":
                case "Mexico":
                    Console.WriteLine("Spanish");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
