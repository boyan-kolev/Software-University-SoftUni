using System;

namespace p08_CaloriesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfIngredients = int.Parse(Console.ReadLine());
            int totalCaloriesAmount = 0;
            for (int i = 0; i < numberOfIngredients; i++)
            {
                String ingredients = Console.ReadLine().ToLower();
                switch (ingredients)
                {
                    case "cheese":
                        totalCaloriesAmount += 500;
                        break;
                    case "tomato sauce":
                        totalCaloriesAmount += 150;
                        break;
                    case "salami":
                        totalCaloriesAmount += 600;
                        break;
                    case "pepper":
                        totalCaloriesAmount += 50;
                        break;
                }
            }
            Console.WriteLine($"Total calories: {totalCaloriesAmount}");
        }
    }
}
