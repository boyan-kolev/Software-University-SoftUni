using System;

namespace problem3_EmployeeData
{
    class Program
    {
        static void Main(string[] args)
        {
            String name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int employeeID = int.Parse(Console.ReadLine());
            double monthlySalary = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Employee ID: {employeeID:d8}");
            Console.WriteLine($"Salary: {monthlySalary:f2}");
        }
    }
}
