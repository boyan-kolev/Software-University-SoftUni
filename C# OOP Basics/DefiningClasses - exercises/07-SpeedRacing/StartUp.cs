using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_SpeedRacing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countOfCars = int.Parse(Console.ReadLine());
            HashSet<Car> cars = new HashSet<Car>();

            for (int counter = 0; counter < countOfCars; counter++)
            {
                string[] tokensInput = Console.ReadLine().Split();
                string model = tokensInput[0];
                double fuelAmount = double.Parse(tokensInput[1]);
                double fuelConsumption = double.Parse(tokensInput[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption);

                if (cars.Contains(car) == false)
                {
                    cars.Add(car);
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string model = tokens[1];
                double amountOfKm = double.Parse(tokens[2]);

                Car car = cars.Where(x => x.Model == model).FirstOrDefault();

                if (car.IsCanMove(amountOfKm))
                {
                    car.ReducedWithUsedFuel(amountOfKm);
                    car.IncreasedTraveledDistance(amountOfKm);
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
