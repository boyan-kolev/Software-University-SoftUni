using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Command
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public void IncreasePrice(int amount)
        {
            this.Price += amount;
            Console.WriteLine($"The price for the {Name} has been increased by {amount}$");
        }

        public void DecreasePrice(int amount)
        {
            if (amount < Price)
            {
                this.Price -= amount;
                Console.WriteLine($"The price for the {Name} has been decreased by {amount}$");
            }
        }

        public override string ToString()
        {
            return $"Current price for the {Name} product is {Price}$";
        }
    }
}
