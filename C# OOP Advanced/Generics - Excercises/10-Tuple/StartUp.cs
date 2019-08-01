namespace Tuple
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string fullName = personInfo[0] + " " + personInfo[1];
            string address = personInfo[2];

            string[] beerInfo = Console.ReadLine().Split();
            string name = beerInfo[0];
            int litersOfBeer = int.Parse(beerInfo[1]);

            string[] numbers = Console.ReadLine().Split();
            int numberInt = int.Parse(numbers[0]);
            double numberDouble = double.Parse(numbers[1]);

            Console.WriteLine(new SpecialTuple<string, string>(fullName, address));
            Console.WriteLine(new SpecialTuple<string, int>(name, litersOfBeer));
            Console.WriteLine(new SpecialTuple<int, double>(numberInt, numberDouble));
        }
    }
}
