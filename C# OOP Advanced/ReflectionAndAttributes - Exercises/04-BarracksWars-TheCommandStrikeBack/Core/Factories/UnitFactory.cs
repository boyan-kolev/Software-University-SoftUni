﻿namespace _03BarracksFactory.Core.Factories
{
    using System.Reflection;
    using Contracts;
    using System.Linq;
    using System;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().First(t => t.Name == unitType);
            IUnit instance = (IUnit)Activator.CreateInstance(type, true);

            return instance;
        }
    }
}
