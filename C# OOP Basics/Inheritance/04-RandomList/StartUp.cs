using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            randomList.Add("Bobi");
            randomList.Add("Misho");
            randomList.Add("Pesho");
            randomList.Add("Gosho");
            randomList.Add("Mimi");
            randomList.Add("Elevan");

            string randomElement = randomList.RandomString();
            Console.WriteLine(randomElement);
        }
    }
}
