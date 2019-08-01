using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Contracts;
using WildFarm.Animals.Factory;
using WildFarm.Foods;
using WildFarm.Foods.Factory;

namespace WildFarm.Core
{
    public class Engine
    {
        private BirdFactory birdFactory;
        private MammalFactory MammalFactory;
        private FelineFactory FelineFactory;
        private FoodFactory foodFactory;
        private List<IAnimal> animals;
        private IAnimal animal;

        public Engine()
        {
            this.birdFactory = new BirdFactory();
            this.MammalFactory = new MammalFactory();
            this.FelineFactory = new FelineFactory();
            this.foodFactory = new FoodFactory();
            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                try
                {
                    string[] animalInfo = input.Split();

                    string animalType = animalInfo[0];
                    string animalName = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);

                    if (animalType == "Cat" || animalType == "Tiger")
                    {
                        string livingRegion = animalInfo[3];
                        string breed = animalInfo[4];
                        this.animal = this.FelineFactory.CreateFeline
                            (animalType, animalName, weight, livingRegion, breed);
                    }
                    else if (animalType == "Hen" || animalType == "Owl")
                    {
                        double wingSize = double.Parse(animalInfo[3]);
                        animal = this.birdFactory.CreateBird(animalType, animalName, weight, wingSize);
                    }
                    else if (animalType == "Mouse" || animalType == "Dog")
                    {
                        string livingRegion = animalInfo[3];
                        animal = this.MammalFactory.CreateMammal(animalType, animalName, weight, livingRegion);
                    }

                    string[] foodInfo = Console.ReadLine().Split();
                    string foodType = foodInfo[0];
                    int foodQuantity = int.Parse(foodInfo[1]);
                    Food food = this.foodFactory.CreateFood(foodType, foodQuantity);

                    animals.Add(animal);
                    animal.ProduceSound();
                    animal.Eat(food);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (IAnimal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
