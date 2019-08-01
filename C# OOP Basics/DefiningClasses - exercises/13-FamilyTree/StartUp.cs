using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static List<string> relationships;
        static List<Person> people;

        static void Main(string[] args)
        {
            string targetPerson = Console.ReadLine();
            relationships = new List<string>();
            people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input.Contains("-") == false)
                {
                    AddMember(input);
                    continue;
                }

                relationships.Add(input);
            }

            foreach (string relationship in relationships)
            {
                string[] tokens = relationship.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string parentInput = tokens[0];
                string childInput = tokens[1];

                bool isParentBirthday = DateTime.TryParse(parentInput, out _);
                bool isChildBirthday = DateTime.TryParse(childInput, out _);

                Person parent = GetPerson(parentInput);
                Person child = GetPerson(childInput);

                if (parent.Children.Contains(child) == false)
                {
                    parent.Children.Add(child);
                }
                if (child.Parents.Contains(parent) == false)
                {
                    child.Parents.Add(parent);
                }
            }

            Print(targetPerson);
        }

        private static void Print(string targetPerson)
        {
            Person person = GetPerson(targetPerson);

            Console.WriteLine($"{person.Name} {person.Birthday}");
            Console.WriteLine("Parents:");
            foreach (Person parent in person.Parents)
            {
                Console.WriteLine($"{parent.Name} {parent.Birthday}");
            }
            Console.WriteLine("Children:");
            foreach (Person child in person.Children)
            {
                Console.WriteLine($"{child.Name} {child.Birthday}");
            }
        }

        private static Person GetPerson(string personString)
        {
            Person person;
            if (personString.Contains("/"))
            {
                person = people.FirstOrDefault(p => p.Birthday == personString);
            }
            else
            {
                person = people.FirstOrDefault(p => p.Name == personString);
            }

            return person;
        }

        private static void AddMember(string input)
        {
            string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0] + " " + tokens[1];
            string birthday = tokens[2];
            Person person = new Person(name, birthday);
            people.Add(person);

        }
    }
}
