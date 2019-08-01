using BirthdayCelebrations.Contracts;
using BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations.Core
{
    public class Engine
    {
        private List<IIdentifiable> inhabitants;
        private List<IBirthable> birthdates;
        public Engine()
        {
            this.inhabitants = new List<IIdentifiable>();
            this.birthdates = new List<IBirthable>();
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string type = tokens[0].ToLower();

                if (type == "robot")
                {
                    string model = tokens[1];
                    string id = tokens[2];

                    IIdentifiable robot = new Robot(model, id);
                    this.inhabitants.Add(robot);
                }
                else if (type == "citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];

                    IBirthable citizen = new Citizen(name, age, id, birthdate);
                    this.birthdates.Add(citizen);
                }
                else if (type == "pet")
                {
                    string name = tokens[1];
                    string birthdate = tokens[2];

                    IBirthable pet = new Pet(birthdate, name);
                    this.birthdates.Add(pet);
                }
            }

            string year = Console.ReadLine();

            foreach (IBirthable birthdate in this.birthdates.Where(x => x.Birthdate.EndsWith(year)))
            {
                Console.WriteLine(birthdate.Birthdate);
            }

        }
    }
}
