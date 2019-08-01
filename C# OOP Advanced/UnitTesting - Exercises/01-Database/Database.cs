namespace _01_Database
{
    using System;
    using System.Linq;

    public class Database
    {
        private const int Capacity = 16;
        private int[] data;
        private int index;

        public Database()
        {
            this.data = new int[Capacity];
            this.index = -1;
        }
        public Database(int[] values)
            : this()
        {
            if (values.Length > Capacity)
            {
                throw new InvalidOperationException("Parameter is too long !");
            }

            for (int i = 0; i < values.Length; i++)
            {
                this.data[i] = values[i];
            } 

            this.index = values.Length - 1;
        }


        public void Add(int element)
        {
            if (this.index < Capacity - 1)
            {
                this.data[++this.index] = element;
                return;
            }

            throw new InvalidOperationException("Database is full !");
        }

        public void Remove()
        {
            if (this.index == -1)
            {
                throw new InvalidOperationException("Database is empty !");
            }

            this.data[index--] = 0;
        }

        public int[] Fetch()
        {
            return this.data
                .Take(this.index + 1)
                .ToArray();
        }

    }
}
