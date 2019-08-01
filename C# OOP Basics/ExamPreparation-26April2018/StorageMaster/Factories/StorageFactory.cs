using StorageMaster.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            Storage storage = null;
            type = type.ToLower();

            switch (type)
            {
                case "automatedwarehouse":
                    storage = new AutomatedWarehouse(name);
                    break;
                case "distributioncenter":
                    storage = new DistributionCenter(name);
                    break;
                case "warehouse":
                    storage = new Warehouse(name);
                    break;
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }

            return storage;
        }
    }
}
