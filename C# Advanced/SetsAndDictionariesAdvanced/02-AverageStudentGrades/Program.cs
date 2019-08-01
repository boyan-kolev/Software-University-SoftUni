using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> grades = new Dictionary<string, List<double>>();

            for (int counter = 0; counter < number; counter++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                double grade = double.Parse(input[1]);

                if (grades.ContainsKey(name) == false)
                {
                    grades.Add(name, new List<double>());
                }

                grades[name].Add(grade);
            }

            foreach (var kvp in grades)
            {
                Console.Write($"{kvp.Key} -> ");

                foreach (double grade in kvp.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {kvp.Value.Average():f2})");
            }
        }
    }
}
