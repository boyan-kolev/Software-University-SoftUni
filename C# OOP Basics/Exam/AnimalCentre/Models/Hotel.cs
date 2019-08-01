using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models
{
    public class Hotel : IHotel
    {
        private const int capacity = 10;
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public int Capacity
        {
            get { return capacity; }
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get { return this.animals; }
        }

        public void Accommodate(IAnimal animal)
        {
            if (this.Animals.Count >= this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (this.Animals.ContainsKey(animalName) == false)
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            this.Animals[animalName].Owner = owner;
            this.Animals[animalName].IsAdopt = true;
            this.animals.Remove(animalName);
        }

    }
}
