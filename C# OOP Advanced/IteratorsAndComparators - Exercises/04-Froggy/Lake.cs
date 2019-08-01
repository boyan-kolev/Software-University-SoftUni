namespace Froggy
{
    using System.Collections;
    using System.Collections.Generic;
    public class Lake : IEnumerable<int>
    {
        private int[] stoneNumbers;

        public Lake(int[] stoneNumbers)
        {
            this.stoneNumbers = stoneNumbers;
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stoneNumbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.stoneNumbers[i];
                }
            }

            for (int i = this.stoneNumbers.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.stoneNumbers[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
