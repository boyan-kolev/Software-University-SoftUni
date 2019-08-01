using System;
using System.Collections.Generic;
using System.Text;

class Car
{
    private string model;
    private Engine engine;
    private string weight;
    private string color;

    public Car(string model, Engine engine, string weight, string color)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }
    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    public string Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public override string ToString()
    {
        return $"{this.Model}:{Environment.NewLine}  {Engine.Model}:{Environment.NewLine}    " +
            $"Power: {Engine.Power}{Environment.NewLine}    Displacement: {Engine.Displacement}" +
            $"{Environment.NewLine}    Efficiency: {Engine.Efficiency}" +
            $"{Environment.NewLine}  Weight: {this.Weight}" +
            $"{Environment.NewLine}  Color: {this.Color}";
    }
}
