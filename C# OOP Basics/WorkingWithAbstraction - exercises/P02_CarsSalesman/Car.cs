using System;
using System.Collections.Generic;
using System.Text;

namespace CarsSalesman
{
    public class Car
    {
        private const string offset = "  ";
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = -1;
            Color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine, color)
        {
            Weight = weight;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}:\n", Model);
            sb.Append(Engine.ToString());
            sb.AppendFormat("{0}Weight: {1}\n", offset, Weight == -1 ? "n/a" : Weight.ToString());
            sb.AppendFormat("{0}Color: {1}", offset, Color);

            return sb.ToString();
        }
    }
}
