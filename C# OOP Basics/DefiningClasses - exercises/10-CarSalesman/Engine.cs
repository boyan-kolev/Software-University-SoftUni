using System;
using System.Collections.Generic;
using System.Text;

class Engine
{
    private string model;
    private double power;
    private string displacement;
    private string effinciency;

    public Engine(string model, double power, string displacement, string efficiency)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }
    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public double Power
    {
        get { return power; }
        set { power = value; }
    }

    public string Displacement
    {
        get { return displacement; }
        set { displacement = value; }
    }

    public string Efficiency
    {
        get { return effinciency; }
        set { effinciency = value; }
    }

}
