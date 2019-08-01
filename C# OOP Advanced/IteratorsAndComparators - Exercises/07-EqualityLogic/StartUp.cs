namespace StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> peopleByHash = new HashSet<Person>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                Person person = new Person(name, age);

                sortedPeople.Add(person);
                peopleByHash.Add(person);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(peopleByHash.Count);
        }
    }
}
