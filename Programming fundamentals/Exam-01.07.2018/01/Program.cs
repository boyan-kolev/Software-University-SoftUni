using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int employee1 = int.Parse(Console.ReadLine());
            int employee2 = int.Parse(Console.ReadLine());
            int employee3 = int.Parse(Console.ReadLine());

            int studentsCount = int.Parse(Console.ReadLine());

            int totalEmployee = employee1 + employee2 + employee3;
            int answerdStundents = 0;
            int count = 0;
            int totalCount = 0;
            if (studentsCount == 0)
            {
                Console.WriteLine($"Time needed: 0h.");
                return;
            }

            while (true)
            {
                if (count == 3)
                {
                    totalCount += 1;
                    count = 0;
                    continue;
                }

                answerdStundents += totalEmployee;
                count++;
                totalCount++;

                if (answerdStundents >= studentsCount)
                {
                    break;
                }
            }

            Console.WriteLine($"Time needed: {totalCount}h.");

        }
    }
}
