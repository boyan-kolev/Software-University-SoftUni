using System;

namespace P02_Facade
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new CarBuilderFacade()
               .Info
                .WithColor("Green")
                .WithType("Combi")
                .WithNumberOfDoors(5)
               .Built
                .InCity("Kazanluk")
                .AtAddress("Str.Gen.Radecki")
                .Bulild();

            Console.WriteLine(car);
        }
    }
}
