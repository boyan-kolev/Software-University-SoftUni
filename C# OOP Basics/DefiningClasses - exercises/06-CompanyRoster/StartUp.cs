using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());
            Dictionary<string, List<Employee>> departments = new Dictionary<string, List<Employee>>();

            for (int counter = 0; counter < countOfLines; counter++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];
                string email = "n/a";
                int age = -1;

                if (input.Length == 6)
                {
                    email = input[4];
                    age = int.Parse(input[5]);
                }
                else if (input.Length == 5)
                {
                    if (int.TryParse(input[4], out int result))
                    {
                        age = result;
                    }
                    else
                    {
                        email = input[4];
                    }
                }

                if (departments.ContainsKey(department) == false)
                {
                    departments.Add(department, new List<Employee>());
                }

                departments[department].Add(new Employee(name, salary, position, email, age));

            }

            var bestSalary = departments.OrderByDescending(x => x.Value.Average(y => y.salary)).FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {bestSalary.Key}");

            foreach (var employee in bestSalary.Value.OrderByDescending(x => x.salary))
            {
                Console.WriteLine(employee);
            }
        }
    }
}
