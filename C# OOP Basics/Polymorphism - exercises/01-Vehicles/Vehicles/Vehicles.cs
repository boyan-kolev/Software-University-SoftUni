using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Vehicles.Contracts;

namespace Vehicles.Vehicles
{
    public abstract class Vehicles : IVehicles
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Vehicles(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public void Drive(double distance)
        {
            double neededConsumption = this.FuelConsumption * distance;
            if (this.FuelQuantity < neededConsumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= neededConsumption;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public void Refuel(double fuel)
        {
            if (this is Truck)
            {
                fuel *= 0.95;
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
