using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    class Car
    {
        private string model;
        private double speed;

        public Car(string model, double speed)
        {
            this.Model = model;
            this.Speed = speed;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.Speed}{Environment.NewLine}";
        }
    }
}
