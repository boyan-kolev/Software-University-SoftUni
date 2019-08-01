namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using Sets;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type typeInfo = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            ISet instance = (ISet)Activator.CreateInstance(typeInfo, new object[] { name });
            return instance;
   
		}
	}




}
