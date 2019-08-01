using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings 
    {
        private List<string> data = new List<string>();

        public void Push(string element)
        {
            data.Add(element);
        }

        public string Pop()
        {
            string lastElement = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            return lastElement;
        }

        public string Peek()
        {
            return data.Last();
        }

        public bool IsEmpty()
        {
            return data.Count < 1;
        }
    }
}
