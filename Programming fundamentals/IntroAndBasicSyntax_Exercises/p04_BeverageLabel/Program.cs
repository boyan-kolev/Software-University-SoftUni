using System;

namespace p04_BeverageLabel
{
    class Program
    {
        static void Main(string[] args)
        {
            String name = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energyContentPer100 = int.Parse(Console.ReadLine());
            double sugarContentPer100 = double.Parse(Console.ReadLine());

            double totalEnergyContent = (energyContentPer100 * volume) / 100.0; 
            double totalSugarContent = (sugarContentPer100 * volume) / 100.0;

            Console.WriteLine($"{volume}ml {name}: \r\n{totalEnergyContent}kcal, {totalSugarContent}g sugars");

        }
    }
}
