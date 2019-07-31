using System;

namespace p07_CakeIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            String ingredient = string.Empty;
            int countOfIngredient = 0;
            while (true)
            {
                ingredient = Console.ReadLine();
                if (ingredient == "Bake!")
                {
                    break;
                }
                Console.WriteLine($"Adding ingredient {ingredient}.");
                countOfIngredient++;
            }
            Console.WriteLine($"Preparing cake with {countOfIngredient} ingredients.");
        }
    }
}
