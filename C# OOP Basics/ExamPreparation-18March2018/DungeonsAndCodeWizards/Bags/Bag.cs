using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Bags
{
    public abstract class Bag
    {
        private int capacity;
        private List<Item> items;

        protected Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public IReadOnlyCollection<Item> Items
        {
            get { return this.items.AsReadOnly(); }
        }

        public int Load() => this.Items.Sum(x => x.Weight);

        public void AddItem(Item item)
        {
            if (item.Weight + this.Load() > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (this.items.Any(x => x.GetType().Name == name) == false)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            Item item = this.items.FirstOrDefault(x => x.GetType().Name == name);
            this.items.Remove(item);

            return item;
        }
    }
}
