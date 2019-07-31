using System;

namespace _11_ConvertSpeedUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            int time = seconds + minutes * 60 + hours * 3600;
            float speedMetersPerSecond = 1.0f * distance / time * 1.0f;
            float speedKilometersPerhour =(1.0f * distance / 1000) / (1.0f * time / 3600);
            float speedMilesPerHour = (1.0f * distance / 1609) / (1.0f * time / 3600);

            Console.WriteLine($"{speedMetersPerSecond:0.######}");
            Console.WriteLine($"{speedKilometersPerhour:0.######}");
            Console.WriteLine($"{speedMilesPerHour:0.######}");



        }
    }
}
