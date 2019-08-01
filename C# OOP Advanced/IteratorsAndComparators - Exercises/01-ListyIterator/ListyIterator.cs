namespace ListyIterators
{
    using System;
    using System.Collections.Generic;

    public class ListyIterator<T>
    {
        private List<T> elements;
        private int currentIndex = 0;

        public ListyIterator(T[] elements)
        {
            this.elements = new List<T>(elements);
        }
        public IReadOnlyList<T> Elements
        {
            get { return elements.AsReadOnly(); }
            set { }
        }

        

        public bool Move()
        {
            if (this.currentIndex < this.Elements.Count - 1)
            {
                this.currentIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return this.currentIndex < this.Elements.Count - 1;
        }

        public void Print()
        {
            if (this.Elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.Elements[currentIndex]);
        }

    }
}
