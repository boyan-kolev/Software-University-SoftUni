using System;

namespace _19_TheaThePhotographer
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong totalPicture = ulong.Parse(Console.ReadLine());
            ulong filterTime = ulong.Parse(Console.ReadLine());
            ulong percentFilterPicture = ulong.Parse(Console.ReadLine());
            ulong uploadTime = ulong.Parse(Console.ReadLine());

            ulong filterPicture = (ulong)Math.Ceiling(totalPicture * (percentFilterPicture / 100.0));
            ulong totalFilterTime = totalPicture * filterTime;
            ulong totalUploadTime = filterPicture * uploadTime;
            ulong totalTime = totalFilterTime + totalUploadTime;

            int day = 0;
            int hour = 0;
            int minutes = 0;

            while (totalTime > 59)
            {
                if (totalTime >= 86400)
                {
                    totalTime -= 86400;
                    day++;
                }
                if (totalTime >= 3600)
                {
                    totalTime -= 3600;
                    hour++;
                    if (hour > 23)
                    {
                        hour -= 24;
                        day++;
                    }
                }
                if (totalTime >= 60)
                {
                    totalTime -= 60;
                    minutes++;
                    if (minutes > 59)
                    {
                        minutes -= 60;
                        hour++;
                    }
                }

            }
            Console.WriteLine($"{day}:{hour:d2}:{minutes:d2}:{totalTime:d2}");
        }
    }
}
