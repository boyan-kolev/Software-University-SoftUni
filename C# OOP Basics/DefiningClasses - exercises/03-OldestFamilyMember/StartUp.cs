using System;

namespace DefiningClasses
{
    class StartUp
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

            Console.WriteLine(family.GetOldestMember());

        }
    }
}
