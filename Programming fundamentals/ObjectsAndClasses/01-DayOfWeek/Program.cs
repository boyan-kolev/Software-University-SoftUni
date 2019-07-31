using System;
using System.Globalization;

namespace _01_DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string input = Console.ReadLine();
            DateTime date = new DateTime();

            date = DateTime.ParseExact(input, "d-M-yyyy", CultureInfo.InvariantCulture);

            
            //Console.Write(dayOfWeek.ToString("d/MMM/yyyy", new CultureInfo("bg-BG")));

            Console.WriteLine(date.DayOfWeek);
        }
    }
}
