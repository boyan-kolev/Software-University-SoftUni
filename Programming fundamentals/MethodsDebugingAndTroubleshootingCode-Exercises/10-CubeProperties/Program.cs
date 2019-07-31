using System;

namespace _10_CubeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            String type = Console.ReadLine();
            double propertyOfCube = FindPropertiesOfCube(side, type);
            Console.WriteLine("{0:f2}",propertyOfCube);
        }

        static double FindPropertiesOfCube(double side ,String type)
        {
            double result = 0.0;
            if (type == "face")
            {
                result = Math.Sqrt(2 * Math.Pow(side, 2));
            }
            else if (type == "space")
            {
                result = Math.Sqrt(3 * Math.Pow(side, 2));
            }
            else if (type == "volume")
            {
                result = Math.Pow(side, 3);
            }
            else if (type == "area")
            {
                result = 6 * Math.Pow(side, 2);
            }
            return result;
        }
    }
}
