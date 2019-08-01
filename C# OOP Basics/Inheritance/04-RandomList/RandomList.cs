using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public Random random { get; set; }

        public RandomList()
        {
            random = new Random();
        }

        public string RandomString()
        {
            int index = random.Next(0, Count - 1);
            string result = this[index];
            RemoveAt(index);

            return result;
        }
    }
}
