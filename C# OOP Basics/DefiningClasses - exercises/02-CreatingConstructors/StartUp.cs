using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            people.Add(new Person("Gosho", 20));
            people.Add(new Person("Pesho", 23));
            people.Add(new Person("Prakash", 18));
            people.Add(new Person("Hristo", 10));
            people.Add(new Person("Ivan", 6));

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
