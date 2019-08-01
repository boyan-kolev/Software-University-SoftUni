using FoodShortage.Contracts;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodShortage.Core
{
    public class Engine
    {
        private List<IBuyer> buyers;
        public Engine()
        {
            this.buyers = new List<IBuyer>();
        }
        public void Run()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < numberOfLines; counter++)
            {
                string[] inputArgs = Console.ReadLine().Split();

                if (inputArgs.Length == 3)
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string group = inputArgs[2];

                    IBuyer buyer = new Rebel(name, age, group);
                    buyers.Add(buyer);
                }
                else
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string id = inputArgs[2];
                    string birthdate = inputArgs[3];

                    IBuyer buyer = new Citizen(name, age, id, birthdate);
                    buyers.Add(buyer);
                }
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                IBuyer buyer = buyers.FirstOrDefault(x => x.Name == input);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }

                input = Console.ReadLine();
            }

            int totalAmountOfFood = buyers.Sum(x => x.Food);
            Console.WriteLine(totalAmountOfFood);
        }
    }
}
