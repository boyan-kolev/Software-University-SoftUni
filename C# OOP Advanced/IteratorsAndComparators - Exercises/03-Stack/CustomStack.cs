namespace Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomStack<T> : IEnumerable<T>
    {
        private Node<T> topNode;

        public CustomStack()
        {
            this.topNode = null;
        }

        public void Push(T element)
        {
            Node<T> newNode = new Node<T>(element);

            if (this.topNode == null)
            {
                this.topNode = newNode;
            }
            else
            {
                Node<T> currentNode = this.topNode;
                this.topNode = newNode;
                this.topNode.PrevNode = currentNode;
            }
        }

        public T Pop()
        {
            if (this.topNode != null)
            {
                T returnedValue = this.topNode.Element;
                this.topNode = this.topNode.PrevNode;
                return returnedValue;
            }
            else
            {
                throw new InvalidOperationException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = this.topNode;

            while (currentNode != null)
            {
                yield return currentNode.Element;
                currentNode = currentNode.PrevNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class Node<T>
        {
            public Node(T element)
            {
                this.Element = element;
                this.PrevNode = null;
            }
            public T Element { get; set; }
            public Node<T> PrevNode { get; set; }
        }
    }
}
