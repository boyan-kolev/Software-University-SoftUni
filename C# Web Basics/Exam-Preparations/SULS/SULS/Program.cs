using SIS.MvcFramework;
using System;
using System.Threading.Tasks;

namespace SULS
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
