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
            string[] busArgs = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carArgs[1]);
            double carFuelConsumption = double.Parse(carArgs[2]);
            double carTankCapacity = double.Parse(carArgs[3]);

            double truckFuelQuantity = double.Parse(truckArgs[1]);
            double truckFuelConsumption = double.Parse(truckArgs[2]);
            double truckTankCapacity = double.Parse(truckArgs[3]);

            double busFuelQuantity = double.Parse(busArgs[1]);
            double busFuelConsumption = double.Parse(busArgs[2]);
            double busTankCapacity = double.Parse(busArgs[3]);

            IVehicles car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
            IVehicles truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
            IVehicles bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

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
                        else if (vehiclesType == "Truck")
                        {
                            truck.Drive(value);
                        }
                        else if (vehiclesType == "Bus")
                        {
                            bus.IsEmptyVehicle = false;
                            bus.Drive(value);
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehiclesType == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehiclesType == "Truck")
                        {
                            truck.Refuel(value);
                        }
                        else if (vehiclesType == "Bus")
                        {
                            bus.Refuel(value);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        bus.IsEmptyVehicle = true;
                        bus.Drive(value);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
