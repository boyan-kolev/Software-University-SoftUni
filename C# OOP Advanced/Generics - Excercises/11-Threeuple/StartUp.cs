namespace Threeuple
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string fullName = personInfo[0] + " " + personInfo[1];
            string address = personInfo[2];
            string town = personInfo[3];

            string[] beerInfo = Console.ReadLine().Split();
            string name = beerInfo[0];
            int litersOfBeer = int.Parse(beerInfo[1]);
            bool isDrunk = beerInfo[2] == "drunk";

            string[] bankAccount = Console.ReadLine().Split();
            string accountName = bankAccount[0];
            double bankBalance = double.Parse(bankAccount[1]);
            string bankName = bankAccount[2];

            Console.WriteLine(new Threeuple<string, string, string>(fullName, address, town));
            Console.WriteLine(new Threeuple<string, int, bool>(name, litersOfBeer, isDrunk));
            Console.WriteLine(new Threeuple<string, double, string>(accountName, bankBalance, bankName));
        }
    }
}
