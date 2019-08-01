using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfMembers = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int counter = 0; counter < numberOfMembers; counter++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                family.AddMember(new Person(name, age));

            }

            List<Person> peopleOver30YearsOld = family.GetMoreThan30YearsOld();

            foreach (Person person in peopleOver30YearsOld.OrderBy(p => p.Name))
            {
                Console.WriteLine(person);
            }

        }
    }
}
