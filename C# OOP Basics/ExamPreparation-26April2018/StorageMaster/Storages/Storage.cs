using StorageMaster.Products;
using StorageMaster.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Storages
{
    public abstract class Storage
    {
        private string name;
        private int capacity;
        private int garageSlots;
        private List<Product> products;
        private Vehicle[] garage;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.products = new List<Product>();
            this.garage = new Vehicle[this.GarageSlots];
            this.FillGarageWithInitialVehicles(vehicles);  
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        
        public int GarageSlots
        {
            get { return garageSlots; }
            set { garageSlots = value; }
        }

        public IReadOnlyCollection<Product> Products
        {
            get { return this.products.AsReadOnly(); }
        }

        public IReadOnlyCollection<Vehicle> Garage
        {
            get { return Array.AsReadOnly(this.garage); }
        }

        public bool IsFull => this.products.Sum(p => p.Weight) >= this.Capacity;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            Vehicle vehicle = this.garage[garageSlot];

            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);
            int foundGarageSlotIndex = deliveryLocation.AddVehicleToGarage(vehicle);
            this.garage[garageSlot] = null;

            return foundGarageSlotIndex;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = this.GetVehicle(garageSlot);
            int numberOfUnoadedProducts = 0;

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                Product product = vehicle.Unload();
                this.products.Add(product);
                numberOfUnoadedProducts++;
            }

            return numberOfUnoadedProducts;
        }
        private void FillGarageWithInitialVehicles(IEnumerable<Vehicle> vehicles)
        {
            int index = 0;

            foreach (Vehicle vehicle in vehicles)
            {
                this.garage[index] = vehicle;
                index++;
            }
        }

        private int AddVehicleToGarage(Vehicle vehicle)
        {
            int freeGarageSlotIndex = Array.IndexOf(this.garage, null);

            if (freeGarageSlotIndex == -1)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[freeGarageSlotIndex] = vehicle;

            return freeGarageSlotIndex;
        }
    }
}
