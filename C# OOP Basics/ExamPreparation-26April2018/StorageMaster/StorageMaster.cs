using StorageMaster.Factories;
using StorageMaster.Products;
using StorageMaster.Storages;
using StorageMaster.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster
{
    public class StorageMaster
    {
        private ProductFactory productFactory;
        private VehicleFactory vehicleFactory;
        private StorageFactory storageFactory;

        private Dictionary<string, Stack<Product>> products;
        private List<Storage> storages;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.productFactory = new ProductFactory();
            this.vehicleFactory = new VehicleFactory();
            this.storageFactory = new StorageFactory();

            this.products = new Dictionary<string, Stack<Product>>();
            this.storages = new List<Storage>();
        }
        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);

            if (this.products.ContainsKey(type) == false)
            {
                products.Add(type, new Stack<Product>());
            }

            products[type].Push(product);
            string result = $"Added {type} to pool";

            return result;
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);
            this.storages.Add(storage);

            string result = $"Registered {name}";
            return result;
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages.FirstOrDefault(x => x.Name == storageName);
            this.currentVehicle = storage.GetVehicle(garageSlot);

            string result = $"Selected {this.currentVehicle.GetType().Name}";
            return result;
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;

            foreach (string productName in productNames)
            {
                if (currentVehicle.IsFull)
                {
                    break;
                }

                if (!products.ContainsKey(productName) ||
                    products[productName].Count == 0)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                Product product = this.products[productName].Pop();
                currentVehicle.LoadProduct(product);
                loadedProductsCount++;
            }

            string result = $"Loaded {loadedProductsCount}/{productNames.Count()} products into {currentVehicle.GetType().Name}";
            return result;
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage sourceStorage = this.storages.FirstOrDefault(x => x.Name == sourceName);
            Storage destinationStorage = this.storages.FirstOrDefault(x => x.Name == destinationName);

            if (sourceStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (destinationStorage == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            string result = $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
            return result;
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages.FirstOrDefault(x => x.Name == storageName);
            Vehicle vehicle = storage.GetVehicle(garageSlot);

            int productsInVehicle = vehicle.Trunk.Count();
            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            string result = $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";

            return result;
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storages.FirstOrDefault(x => x.Name == storageName);

            Dictionary<string, int> products = new Dictionary<string, int>();

            foreach (Product product in storage.Products)
            {
                string productType = product.GetType().Name;

                if (products.ContainsKey(productType) == false)
                {
                    products.Add(productType, 0);
                }

                products[productType]++;
            }

            var sortedProduct = products.OrderByDescending(x => x.Value).ThenBy(x => x.Key);


            string[] productsAsString = new string[products.Count];

            int index = 0;

            foreach (var product in products)
            {
                string currResult = $"{product.Key} ({product.Value})";
                productsAsString[index] = currResult;
                index++;
            }

            List<string> vehicles = new List<string>();

            foreach (Vehicle vehicle in storage.Garage)
            {
                if (vehicle == null)
                {
                    vehicles.Add("empty");
                }
                else
                {
                    vehicles.Add(vehicle.GetType().Name);
                }
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine
                ($"Stock ({storage.Products.Sum(x => x.Weight)}/{storage.Capacity}): [{string.Join(",", productsAsString)}]");

            stringBuilder.Append($"Garage: [{string.Join("|", vehicles)}]");

            string result = stringBuilder.ToString();
            return result;

        }

        public string GetSummary()
        {
            List<Storage> sortedsSorages = this.storages
                .OrderByDescending(x => x.Products.Sum(p => p.Price))
                .ToList();

            List<string> storagesAsString = new List<string>();

            foreach (Storage storage in sortedsSorages)
            {
                storagesAsString.Add($"{storage.Name}:"
                    + Environment.NewLine
                    + $"Storage worth: ${storage.Products.Sum(x => x.Price):F2}");
            }

            string result = string.Join(Environment.NewLine, storagesAsString);
            return result;
        }

    }
}
