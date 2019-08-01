using BorderControl.Contracts;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl.Core
{
    public class Engine
    {
        private List<IIdentifiable> inhabitants;
        public Engine()
        {
            this.inhabitants = new List<IIdentifiable>();
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    string id = tokens[1];

                    IIdentifiable robot = new Robot(model, id);
                    this.inhabitants.Add(robot);
                }
                else
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    IIdentifiable citizen = new Citizen(name, age, id);
                    this.inhabitants.Add(citizen);
                }
            }

            string fakeId = Console.ReadLine();

            foreach (IIdentifiable inhabitant in this.inhabitants.Where(x => x.Id.EndsWith(fakeId)))
            {
                Console.WriteLine(inhabitant.Id);
            }

            this.inhabitants.RemoveAll(x => x.Id.EndsWith(fakeId));
        }
    }
}
