using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int amountOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int counter = 0; counter < amountOfCars; counter++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                List<Tire> tires = new List<Tire>();

                for (int i = 0; i < 8; i += 2)
                {
                    double tirePressure = double.Parse(input[5 + i]);
                    int tireAge = int.Parse(input[6 + i]);

                    Tire tire = new Tire(tirePressure, tireAge);
                    tires.Add(tire);
                }

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            List<Car> resultCars = new List<Car>();

            if (command == "fragile")
            {
                resultCars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1)).ToList();
            }
            else if (command == "flamable")
            {
                resultCars = cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList();
            }

            foreach (Car car in resultCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
