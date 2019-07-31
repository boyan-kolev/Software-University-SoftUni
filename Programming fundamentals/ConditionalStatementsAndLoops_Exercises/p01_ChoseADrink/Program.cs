using System;

namespace p01_ChoseADrink
{
    class Program
    {
        static void Main(string[] args)
        {
            String profession = Console.ReadLine().ToLower();
            String drink = String.Empty;

            switch (profession)
            {
                case "athlete":
                    drink = "Water";
                    break;
                case "businessman":
                case "businesswoman":
                    drink = "Coffee";
                    break;
                case "softuni student":
                    drink = "Beer";
                    break;
                default:
                    drink = "Tea";
                    break;
            }
            Console.WriteLine(drink);
        }
    }
}
