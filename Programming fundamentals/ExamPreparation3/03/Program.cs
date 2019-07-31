using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            double[] zones = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            int[] checpoints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
  

            foreach (var name in names)
            {
                double fuel = (int)name[0];
                bool isFinished = true;

                for (int i = 0; i < zones.Length; i++)
                {

                    if (checpoints.Contains(i))
                    {
                        fuel += zones[i];
                    }
                    else
                    {
                        fuel -= zones[i];
                    }

                    if (fuel <= 0)
                    {
                        fuel = i;
                        isFinished = false;
                        break;
                    }
                }

                if (isFinished)
                {
                    Console.WriteLine($"{name} - fuel left {fuel:f2}");
                }
                else
                {
                    Console.WriteLine($"{name} - reached {fuel}");
                }

            }
        }
    }
}
