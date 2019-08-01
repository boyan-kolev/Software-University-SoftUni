using System;
using System.Collections.Generic;
using System.Text;

class Car
{
    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    private double fuelAmount;

    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    private double fuelConsumption;

    public double FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    private double traveledDistance;

    public double TraveledDistance
    {
        get { return traveledDistance; }
        set { traveledDistance = value; }
    }

    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumption = fuelConsumption;
    }

    public bool IsCanMove(double amountOfKm)
    {
        return this.fuelAmount - (this.fuelConsumption * amountOfKm) >= 0;
    }

    public void ReducedWithUsedFuel(double amountOfKm)
    {
        this.fuelAmount -= (this.fuelConsumption * amountOfKm);
    }

    public void IncreasedTraveledDistance(double amountOfKm)
    {
        this.traveledDistance += amountOfKm;
    }

    public override string ToString()
    {
        return $"{this.model} {this.fuelAmount:f2} {this.traveledDistance}";
    }


}

