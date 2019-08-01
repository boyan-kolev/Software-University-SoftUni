using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Vehicles.Contracts
{
    public interface IVehicles
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double TankCapacity { get; }
        bool IsEmptyVehicle { get; set; }
        void Drive(double distance);
        void Refuel(double fuel);
    }
}
