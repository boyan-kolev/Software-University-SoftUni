namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            Type typeInfo = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            IItem item = (IItem)Activator.CreateInstance(typeInfo);

            return item;
		}
	}
}
