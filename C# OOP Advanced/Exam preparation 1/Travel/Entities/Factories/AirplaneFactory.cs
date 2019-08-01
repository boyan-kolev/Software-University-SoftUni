namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System;
    using System.Reflection;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            Type typeInfo = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            IAirplane instance = (IAirplane)Activator.CreateInstance(typeInfo);
            return instance;
        }
	}
}