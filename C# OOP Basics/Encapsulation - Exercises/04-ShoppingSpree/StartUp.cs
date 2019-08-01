using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputPersons = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] inputProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            people = GetPerson(inputPersons);
            products = GetProducts(inputProducts);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();
                string personName = tokens[0];
                string productName = tokens[1];
                Product product = products.First(p => p.Name == productName);
                people.First(p => p.Name == personName).AddProduct(product);
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }

        }

        private static List<Product> GetProducts(string[] inputProducts)
        {
            List<Product> products = new List<Product>();

            for (int counter = 0; counter < inputProducts.Length; counter++)
            {
                string[] tokens = inputProducts[counter].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string productName = tokens[0];
                decimal productCost = decimal.Parse(tokens[1]);

                try
                {
                    Product product = new Product(productName, productCost);
                    products.Add(product);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
            }
            return products;
        }

        private static List<Person> GetPerson(string[] inputPersons)
        {
            List<Person> people = new List<Person>();
            for (int counter = 0; counter < inputPersons.Length; counter++)
            {
                string[] tokens = inputPersons[counter].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                decimal personMoney = decimal.Parse(tokens[1]);

                try
                {
                    Person person = new Person(personName, personMoney);
                    people.Add(person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
            }

            return people;
        }
    }
}
