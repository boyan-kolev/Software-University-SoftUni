using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Engine
    {
        public void Run()
        {
            string driverName = Console.ReadLine();
            Ferrari ferrari = new Ferrari(driverName);
            Console.WriteLine($"{ferrari.Model}/{ferrari.UseBrakes()}/{ferrari.PushTheGasPedal()}/{ferrari.DriverName}");
        }
    }
}
