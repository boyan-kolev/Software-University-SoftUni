using System;

namespace choseADrink2
{
    class Program
    {
        static void Main(string[] args)
        {
            String profession = Console.ReadLine();
            int quantities = int.Parse(Console.ReadLine());
            String drink = String.Empty;

            switch (profession)
            {
                case "Athlete":
                    drink = "Water";
                    break;
                case "Businessman":
                case "Businesswoman":
                    drink = "Coffee";
                    break;
                case "SoftUni Student":
                    drink = "Beer";
                    break;
                default:
                    drink = "Tea";
                    break;
            }
            double price = 0.0;
            if (drink == "Water")
            {
                price = 0.70;
            }
            else if (drink == "Coffee")
            {
                price = 1.00;
            }
            else if (drink == "Beer")
            {
                price = 1.70;
            }
            else if (drink == "Tea")
            {
                price = 1.20;
            }
            double totalPrice = quantities * price;
            Console.WriteLine($"The {profession} has to pay {totalPrice:f2}.");
        }
    }
}
