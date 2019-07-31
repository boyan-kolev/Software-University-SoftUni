using System;

namespace _19_TheaThePhotographerWithTimeSpan
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

            TimeSpan time = TimeSpan.FromSeconds(totalTime);
            String dateTime = time.ToString(@"d\:hh\:mm\:ss");
            Console.WriteLine(dateTime);
        }
    }
}
