namespace GenericCountMethodStrings
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
        where T : IComparable<T>
    {
        private List<T> items;

        public List<T> Items
        {
            get { return items; }
            set { items = value; }
        }

        public Box()
        {
            this.Items = new List<T>();
        }

        public void SwapTwoItems(int index1, int index2)
        {
            T tempItem = this.Items[index1];
            this.Items[index1] = this.Items[index2];
            this.Items[index2] = tempItem;
        }

        public int CompareWithElement(T element)
        {
            int count = 0;

            foreach (var item in this.Items)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.Items)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
