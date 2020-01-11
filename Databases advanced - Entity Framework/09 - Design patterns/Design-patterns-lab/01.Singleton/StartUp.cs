using System;

namespace P01_Singleton
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SingletonDataContainer db1 = SingletonDataContainer.Instance;
            Console.WriteLine(db1.GetPopulation("Tokyo"));

            SingletonDataContainer db2 = SingletonDataContainer.Instance;
            Console.WriteLine(db2.GetPopulation("London"));
        }
    }
}
