namespace CustomList
{
    using System;
    using System.Linq;

    public class CustomList<T> : ICustomList<T>
        where T : IComparable<T>
    {
        private const int initialCapacityArray = 4;
        private T[] array;
        public CustomList()
        {
            this.array = new T[initialCapacityArray];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this.array.Length == this.Count)
            {
                this.Resize();
            }

            this.array[this.Count] = element;
            this.Count++;
        }

        public bool Contains(T element)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty !");
            }

            for (int counter = 0; counter < this.Count; counter++)
            {
                if (this.array[counter].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public int CountGreaterThan(T element)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty !");
            }

            int counter = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public T Max()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty !");
            }

            T maxTemp = this.array[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(maxTemp) > 0)
                {
                    maxTemp = this.array[i];
                }
            }

            return maxTemp;
        }

        public T Min()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty !");
            }

            T minTemp = this.array[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(minTemp) < 0)
                {
                    minTemp = this.array[i];
                }
            }

            return minTemp;
        }

        public T Remove(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty !");
            }

            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentException("Invalid index !");
            }

            T removedElement = this.array[index];
            this.array[index] = default(T);
            this.Count--;

            for (int i = index; i < this.Count; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            if (this.array.Length != this.Count)
            {
                this.array[this.Count] = default(T);
            }

            return removedElement;
        }

        public void Swap(int index1, int index2)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty !");
            }

            if (index1 < 0 || index1 >= this.Count ||
                index2 < 0 || index2 >= this.Count)
            {
                throw new ArgumentException("Invalid index !");
            }

            T tempElement = this.array[index1];
            this.array[index1] = this.array[index2];
            this.array[index2] = tempElement;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.array.Take(this.Count));
        }

        private void Resize()
        {
            T[] tempArray = new T[this.array.Length * 2];

            for (int counter = 0; counter < this.array.Length; counter++)
            {
                tempArray[counter] = this.array[counter];
            }

            this.array = tempArray;
        }
    }
}
