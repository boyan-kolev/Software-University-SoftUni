namespace StrategyPattern
{
    using StrategyPattern.CustomComparators;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            NameComparator nameComparator = new NameComparator();
            AgeComparator ageComparator = new AgeComparator();

            SortedSet<Person> nameSortedPeople = new SortedSet<Person>(nameComparator);
            SortedSet<Person> ageSortedPeople = new SortedSet<Person>(ageComparator);

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                Person person = new Person(name, age);

                nameSortedPeople.Add(person);
                ageSortedPeople.Add(person);
            }
            Console.WriteLine();

            Console.WriteLine(string.Join(Environment.NewLine, nameSortedPeople));
            Console.WriteLine(string.Join(Environment.NewLine, ageSortedPeople));
        }
    }
}
