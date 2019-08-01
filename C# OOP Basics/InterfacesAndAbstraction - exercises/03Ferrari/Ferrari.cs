using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : ICar
    {
        private const string model = "488-Spider";

        public string Model
        {
            get { return model; }
        }

        public string DriverName { get; private set; }

        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
        }
        public string PushTheGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }
    }
}
