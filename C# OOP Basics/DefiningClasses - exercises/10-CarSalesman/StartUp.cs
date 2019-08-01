using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_CarSalesman
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int linesOfEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int counter = 0; counter < linesOfEngines; counter++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                double power = double.Parse(input[1]);
                string displacement = "n/a";
                string efficiency = "n/a";

                if (input.Length == 4)
                {
                    displacement = input[2];
                    efficiency = input[3];
                }
                else if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out _))
                    {
                        displacement = input[2];
                    }
                    else
                    {
                        efficiency = input[2];
                    }
                }

                Engine engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);
            }

            int countOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int counter = 0; counter < countOfCars; counter++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                string engineModel = input[1];
                string weight = "n/a";
                string color = "n/a";

                if (input.Length == 4)
                {
                    weight = input[2];
                    color = input[3];
                }
                else if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out _))
                    {
                        weight = input[2];
                    }
                    else
                    {
                        color = input[2];
                    }
                }
                Engine engine = engines.Where(x => x.Model == engineModel).FirstOrDefault();
                Car car = new Car(model, engine, weight, color);
                cars.Add(car);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
