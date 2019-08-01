using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Vehicles
{
    public class Bus : Vehicles
    {
        private const double airConditionConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {   
        }

        public override void Drive(double distance)
        {
            double currFuelConsumption = this.FuelConsumption;

            if (this.IsEmptyVehicle == false)
            {
                currFuelConsumption += airConditionConsumption;
            }

            double neededConsumption = currFuelConsumption * distance;
            if (this.FuelQuantity < neededConsumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= neededConsumption;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");

        }
    }
}
