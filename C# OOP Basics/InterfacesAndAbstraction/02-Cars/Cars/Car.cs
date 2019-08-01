using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public abstract class Car : ICar
    {
        private string model;
        private string colour;

        public Car(string model, string colour)
        {
            this.Model = model;
            this.Colour = colour;
        }

        public string Model { get => this.model; set => this.model = value; }
        public string Colour { get => this.colour; set => this.colour = value; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public virtual string GetCarInfo()
        {
            return $"{this.Colour} {this.GetType().Name} {this.Model}";
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(GetCarInfo());
            stringBuilder.AppendLine(this.Start());
            stringBuilder.Append(this.Stop());

            return stringBuilder.ToString();

        }
    }
}
