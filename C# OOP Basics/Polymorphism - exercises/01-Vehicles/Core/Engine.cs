using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Vehicles;
using Vehicles.Vehicles.Contracts;

namespace Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carArgs = Console.ReadLine().Split();
            string[] truckArgs = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carArgs[1]);
            double carFuelConsumption = double.Parse(carArgs[2]);
            double truckFuelQuantity = double.Parse(truckArgs[1]);
            double truckFuelConsumption = double.Parse(truckArgs[2]);

            IVehicles car = new Car(carFuelQuantity, carFuelConsumption);
            IVehicles truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < numberOfCommands; counter++)
            {
                string[] commandArgs = Console.ReadLine().Split();
                string command = commandArgs[0];
                string vehiclesType = commandArgs[1];
                double value = double.Parse(commandArgs[2]);

                try
                {
                    if (command == "Drive")
                    {
                        if (vehiclesType == "Car")
                        {
                            car.Drive(value);
                        }
                        else
                        {
                            truck.Drive(value);
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehiclesType == "Car")
                        {
                            car.Refuel(value);
                        }
                        else
                        {
                            truck.Refuel(value);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
