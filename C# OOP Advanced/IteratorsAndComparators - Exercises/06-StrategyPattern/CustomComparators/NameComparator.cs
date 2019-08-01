namespace StrategyPattern.CustomComparators
{
    using System;
    using System.Collections.Generic;

    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.Name.Length.CompareTo(y.Name.Length);

            if (result == 0)
            {
                char xFirstLetterToLower = char.ToLower(x.Name[0]);
                char yFirstLetterToLower = char.ToLower(y.Name[0]);
                result = xFirstLetterToLower.CompareTo(yFirstLetterToLower);
            }

            return result;
        }
    }
}
