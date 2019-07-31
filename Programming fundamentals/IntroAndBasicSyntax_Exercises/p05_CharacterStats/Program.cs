using System;

namespace p05_CharacterStats
{
    class Program
    {
        static void Main(string[] args)
        {
            String name = Console.ReadLine();
            int currentHealth = int.Parse(Console.ReadLine());
            int maximumHealth = int.Parse(Console.ReadLine());
            int currentEnergy = int.Parse(Console.ReadLine());
            int maximumEnergy = int.Parse(Console.ReadLine());

            String health = new string('|', currentHealth + 1) + new string('.', (maximumHealth - currentHealth)) + "|";
            String energy = new string('|', currentEnergy + 1) + new string('.', (maximumEnergy - currentEnergy)) + "|";
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: {health}");
            Console.WriteLine($"Energy: {energy}");
        }
    }
}
