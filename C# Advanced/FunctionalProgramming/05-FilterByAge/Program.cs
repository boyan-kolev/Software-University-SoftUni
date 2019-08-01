using System;
using System.Collections.Generic;

namespace _05_FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>(countOfPeople);
            for (int counter = 0; counter < countOfPeople; counter++)
            {
                string[] tokens = Console.ReadLine().Split(", ");
                string name = tokens[0];
                int agePerson = int.Parse(tokens[1]);

                people.Add(name, agePerson);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> filter = CreateFilter(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            foreach (var person in people)
            {
                if (filter(person.Value))
                {
                    printer(person);
                }
            }
        }
        static Func<int, bool> CreateFilter(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x < age;
            }
            else
            {
                return x => x >= age;
            }
        }

        static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
