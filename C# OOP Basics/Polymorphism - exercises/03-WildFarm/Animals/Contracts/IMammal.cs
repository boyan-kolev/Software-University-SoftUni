﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Contracts
{
    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}
