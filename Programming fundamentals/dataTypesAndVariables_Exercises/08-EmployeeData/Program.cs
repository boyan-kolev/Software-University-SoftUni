using System;

namespace _08_EmployeeData
{
    class Program
    {
        static void Main(string[] args)
        {
            String firstName = Console.ReadLine();
            String lastName = Console.ReadLine();
            byte age = byte.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            long numberID = long.Parse(Console.ReadLine());
            int uniqueNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"First name: {firstName}\r\nLast name: {lastName}\r\n" +
                $"Age: {age}\r\nGender: {gender}\r\nPersonal ID: {numberID}\r\n" +
                $"Unique Employee number: {uniqueNumber}");

        }
    }
}
