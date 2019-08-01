using AnimalCentre.Models;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre
{
    public class AnimalCentre
    {
        private IHotel hotel;
        private Chip chip;
        private DentalCare dentalCare;
        private Fitness fitness;
        private NailTrim nailTrim;
        private Play play;
        private Vaccinate vaccinate;
        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.chip = new Chip();
            this.dentalCare = new DentalCare();
            this.fitness = new Fitness();
            this.nailTrim = new NailTrim();
            this.play = new Play();
            this.vaccinate = new Vaccinate();
        }
        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = null;
            switch (type)
            {
                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    break;
                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Cat":
                    animal = new Cat(name, energy, happiness, procedureTime);
                    break;
                default:
                    break;
            }

            this.hotel.Accommodate(animal);

            string result = $"Animal {animal.Name} registered successfully";
            return result;
        }

        public string Chip(string name, int procedureTime)
        {
            if (this.hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal currAnimal = this.hotel.Animals[name];
            this.chip.DoService(currAnimal, procedureTime);

            string result = $"{currAnimal.Name} had chip procedure";
            return result;
        }

        public string Vaccinate(string name, int procedureTime)
        {
            if (this.hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal currAnimal = this.hotel.Animals[name];
            this.vaccinate.DoService(currAnimal, procedureTime);

            string result = $"{currAnimal.Name} had vaccination procedure";
            return result;
        }

        public string Fitness(string name, int procedureTime)
        {
            if (this.hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal currAnimal = this.hotel.Animals[name];
            this.fitness.DoService(currAnimal, procedureTime);

            string result = $"{currAnimal.Name} had fitness procedure";
            return result;
        }

        public string Play(string name, int procedureTime)
        {
            if (this.hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal currAnimal = this.hotel.Animals[name];
            this.play.DoService(currAnimal, procedureTime);

            string result = $"{currAnimal.Name} was playing for {procedureTime} hours";
            return result;
        }

        public string DentalCare(string name, int procedureTime)
        {
            if (this.hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal currAnimal = this.hotel.Animals[name];
            this.dentalCare.DoService(currAnimal, procedureTime);

            string result = $"{currAnimal.Name} had dental care procedure";
            return result;
        }

        public string NailTrim(string name, int procedureTime)
        {
            if (this.hotel.Animals.ContainsKey(name) == false)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal currAnimal = this.hotel.Animals[name];
            this.nailTrim.DoService(currAnimal, procedureTime);

            string result = $"{currAnimal.Name} had nail trim procedure";
            return result;
        }

        public string Adopt(string animalName, string owner)
        {
            if (this.hotel.Animals.ContainsKey(animalName) == false)
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            IAnimal currAnimal = this.hotel.Animals[animalName];
            hotel.Adopt(animalName, owner);

            string result;

            if (currAnimal.IsChipped)
            {
                result = $"{owner} adopted animal with chip";
            }
            else
            {
                result = $"{owner} adopted animal without chip";
            }
            return result;
        }

        public string History(string type)
        {
            switch (type)
            {
                case "Chip":
                   return chip.History();
                case "DentalCare":
                    return dentalCare.History();
                case "Fitness":
                    return fitness.History();
                case "NailTrim":
                    return nailTrim.History();
                case "Play":
                    return play.History();
                case "Vaccinate":
                    return vaccinate.History();
                default:
                    return "";
            }
        }

    }
}
