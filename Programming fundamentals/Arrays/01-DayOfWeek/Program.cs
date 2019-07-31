using System;

namespace _01_DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayNumber = int.Parse(Console.ReadLine());
            String[] dayOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            if (dayNumber >= 1 && dayNumber <= 7)
            {
                Console.WriteLine(dayOfWeek[dayNumber - 1]);
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }

        }
    }
}
