using System;
using System.Collections.Generic;
using System.Linq;

namespace Google
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string PersonName = tokens[0];
                Person person = people.Where(p => p.Name == PersonName).FirstOrDefault();

                if (person == null)
                {
                    person = new Person(PersonName);
                    people.Add(person);
                }

                switch (tokens[1])
                {
                    case "company":
                        string companyName = tokens[2];
                        string department = tokens[3];
                        decimal salary = decimal.Parse(tokens[4]);

                        Company company = new Company(companyName, department, salary);
                        person.Company = company;
                        break;
                    case "car":
                        string carModel = tokens[2];
                        double carSpeed = double.Parse(tokens[3]);

                        Car car = new Car(carModel, carSpeed);
                        person.Car = car;
                        break;
                    case "pokemon":
                        string pokemonName = tokens[2];
                        string pokemonType = tokens[3];

                        Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                        person.Pokemons.Add(pokemon);
                        break;
                    case "parents":
                        string parentName = tokens[2];
                        string parentBirthday = tokens[3];

                        Parent parent = new Parent(parentName, parentBirthday);
                        person.Parents.Add(parent);
                        break;
                    case "children":
                        string childName = tokens[2];
                        string childBirthday = tokens[3];

                        Child child = new Child(childName, childBirthday);
                        person.Children.Add(child);
                        break;
                }
            }

            string name = Console.ReadLine();
            Console.Write(people.FirstOrDefault(x => x.Name == name));
        }
    }
}
