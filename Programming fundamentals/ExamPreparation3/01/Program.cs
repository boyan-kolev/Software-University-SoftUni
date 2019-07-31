using System;
using System.Numerics;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime inputedDate = DateTime.Parse(Console.ReadLine());
            long numberOfSteps = long.Parse(Console.ReadLine()) % 86400;
            long timeForStep = long.Parse(Console.ReadLine()) % 86400;
            long days = numberOfSteps * timeForStep;


            string result = inputedDate.AddSeconds(days).ToString("HH:mm:ss");
            
            

            Console.WriteLine("Time Arrival: " + result);
        }
    }
}
