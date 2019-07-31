using System;

namespace _01_DayOfWeek2
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayNumber = int.Parse(Console.ReadLine());
            DayOfWeek[] daysInEnglish = new DayOfWeek[7]
            {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            };

            if ((dayNumber < 1 || dayNumber > 7) == false)
            {
                Console.WriteLine(daysInEnglish[dayNumber - 1]);
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }

        }
    }
}
