using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Contracts;

namespace WildFarm.Animals.Factory
{
    public class FelineFactory
    {
        public IFeline CreateFeline(string type, string name, double weight, string livingRegion, string breed)
        {
            type = type.ToLower();

            switch (type)
            {
                case "cat":
                    return new Cat(name, weight, livingRegion, breed);
                case "tiger":
                    return new Tiger(name, weight, livingRegion, breed);
                default:
                    throw new ArgumentException("Invalid feline type!");
            }
        }
    }
}
