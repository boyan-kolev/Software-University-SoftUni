using System;
using System.Globalization;

namespace _10_HolidaysBetweenTwoDates
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime.ParseExact(InputDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd"));


            var startDate = DateTime.ParseExact(Console.ReadLine(),
            "d.M.yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture);
            var holidaysCount = 0;
            for (var date = startDate; date <= endDate;date = date.AddDays(1))
                if (date.DayOfWeek == DayOfWeek.Saturday ||
                    date.DayOfWeek == DayOfWeek.Sunday) holidaysCount++;
            Console.WriteLine(holidaysCount);

        }
    }
}
