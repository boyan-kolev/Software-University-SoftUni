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
        private double tankCapacity;

        public Vehicles(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }


        public bool IsEmptyVehicle { get; set; }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }

                fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            protected set { fuelConsumption = value; }
        }


        public double TankCapacity
        {
            get { return tankCapacity; }
            protected set
            {
                tankCapacity = value;
            }
        }


        public virtual void Drive(double distance)
        {
            double neededConsumption = this.FuelConsumption * distance;
            if (this.FuelQuantity < neededConsumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= neededConsumption;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + fuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit { fuel } fuel in the tank");
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
