using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        public int Battery { get ; private set ; }

        public Tesla(string model, string colour, int battery) 
            : base(model, colour)
        {
            this.Battery = battery;
        }

        public override string GetCarInfo()
        {
            return $"{this.Colour} Tesla Model {this.Model} with {this.Battery} Batteries";
        }
    }
}
