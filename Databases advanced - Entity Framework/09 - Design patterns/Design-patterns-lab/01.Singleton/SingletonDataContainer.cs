using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace P01_Singleton
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> capitals = new Dictionary<string, int>();

        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");
            string[] elements = File.ReadAllLines("./../../../Capitals.txt");

            for (int i = 0; i < elements.Length; i += 2)
            {
                string capital = elements[i];
                int population = int.Parse(elements[i + 1]);

                capitals.Add(capital, population);
            }
        }

        private static SingletonDataContainer instance = new SingletonDataContainer();

        public static SingletonDataContainer Instance => instance;

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
