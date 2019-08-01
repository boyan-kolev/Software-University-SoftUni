namespace ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input.Split();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                string town = inputArgs[2];

                Person person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine();
            }

            int comparePosition = int.Parse(Console.ReadLine()) - 1;
            Person comparePerson = people[comparePosition];

            int numberOfEqualPeople = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(comparePerson) == 0)
                {
                    numberOfEqualPeople++;
                }
                
            }

            int numberOfNotEqualPeople = people.Count - numberOfEqualPeople;

            if (numberOfEqualPeople > 1)
            {
                Console.WriteLine($"{numberOfEqualPeople} {numberOfNotEqualPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
