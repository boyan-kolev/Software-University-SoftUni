using StorageMaster.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            Vehicle vehicle = null;
            type = type.ToLower();

            switch (type)
            {
                case "truck":
                    vehicle = new Truck();
                    break;
                case "van":
                    vehicle = new Van();
                    break;
                case "semi":
                    vehicle = new Semi();
                    break;
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }
    }
}
