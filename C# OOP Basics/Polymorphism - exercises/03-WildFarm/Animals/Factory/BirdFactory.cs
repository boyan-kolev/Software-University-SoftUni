using System;
using WildFarm.Animals.Contracts;

namespace WildFarm.Animals.Factory
{
    public class BirdFactory
    {
        public IBird CreateBird(string type, string name, double weight, double wingSize)
        {
            type = type.ToLower();

            switch (type)
            {
                case "owl":
                    return new Owl(name, weight, wingSize);
                case "hen":
                    return new Hen(name, weight, wingSize);
                default:
                    throw new ArgumentException("Invalid bird type!");
            }
        }
    }
}
