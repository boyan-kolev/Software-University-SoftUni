using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Vehicles
{
    public class Truck : Vehicles
    {
        private const double airConditionConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += airConditionConsumption;
        }

        public override void Refuel(double fuel)
        {

            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + fuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit { fuel } fuel in the tank");
            }

            fuel *= 0.95;
            this.FuelQuantity += fuel;
        }
    }
}
