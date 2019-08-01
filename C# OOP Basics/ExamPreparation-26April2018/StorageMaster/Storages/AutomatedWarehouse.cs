﻿using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Vehicles;

namespace StorageMaster.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int AutomatedWarehouseCapacity = 1;
        private const int AutomatedWarehouseGarageSlots = 2;
        private static Vehicle[] DefaultVehicles =
        {
            new Truck()
        };
        public AutomatedWarehouse(string name)
            : base(name, AutomatedWarehouseCapacity, AutomatedWarehouseGarageSlots, DefaultVehicles)
        {
        }
    }
}
