using System;
using System.Collections.Generic;

namespace MyFirstWebApp.Services
{
    public class YearsService : IYearsService
    {
        public IEnumerable<int> GetLastYears(int years)
        {
            int currentYear = DateTime.UtcNow.Year;

            for (int i = currentYear - years; i <= currentYear; i++)
            {
                yield return i;
            }
        }
    }
}


