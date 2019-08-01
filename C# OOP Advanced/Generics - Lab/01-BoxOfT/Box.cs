namespace BoxOfT
{
    using System.Collections.Generic;

    public class Box<T>
    {

        private Stack<T> elements = new Stack<T>();
        public void Add(T element)
        {
            this.elements.Push(element);
        }

        public T Remove()
        {
            T topmostElement = this.elements.Peek();
            this.elements.Pop();
            return topmostElement;
        }

        public int Count => this.elements.Count;
    }
}
