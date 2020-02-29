using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Services
{
    public interface IYearsService
    {
        IEnumerable<int> GetLastYears(int years);
    }
}


