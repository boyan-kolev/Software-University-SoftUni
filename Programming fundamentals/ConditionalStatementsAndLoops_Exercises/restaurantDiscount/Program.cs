using System;

namespace restaurantDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            String package = Console.ReadLine();
            String typeOfHall = String.Empty;
            double price = 0;

            if (groupSize <= 50)
            {
                typeOfHall = "Small Hall";
                price = 2500;
            }
            else if (groupSize <= 100)
            {
                typeOfHall = "Terrace";
                price = 5000;
            }
            else if (groupSize <= 120)
            {
                typeOfHall = "Great Hall";
                price = 7500;
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            double discount = 0.0;
            if (package == "Normal")
            {
                discount = 0.05;
                price += 500;
            }
            else if (package == "Gold")
            {
                discount = 0.10;
                price += 750;
            }
            else if (package == "Platinum")
            {
                discount = 0.15;
                price += 1000;
            }
            double discountPrice = price - (price * discount);
            double pricePerPeople = discountPrice / groupSize;

            Console.WriteLine($"We can offer you the {typeOfHall}");
            Console.WriteLine($"The price per person is {pricePerPeople:f2}$");
        }
    }
}
