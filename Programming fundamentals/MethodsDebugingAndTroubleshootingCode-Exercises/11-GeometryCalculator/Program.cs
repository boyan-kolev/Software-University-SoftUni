using System;

namespace _11_GeometryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            String type = Console.ReadLine();

            double area = 0.0;
            switch (type)
            {
                case "triangle":
                    double side = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    area = CalculateAreaOfTriangle(side, height);
                    break;
                case "square":
                    double sideOfSquare = double.Parse(Console.ReadLine());
                    area = CalculateAreaOfSquare(sideOfSquare);
                    break;
                case "rectangle":
                    double side1 = double.Parse(Console.ReadLine());
                    double side2 = double.Parse(Console.ReadLine());
                    area = CalculateAreaOfRectangle(side1, side2);
                    break;
                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    area = CalculateAreaOfCircle(radius);
                    break;
            }
            Console.WriteLine("{0:f2}", area);
        }

        static double CalculateAreaOfTriangle(double side, double height)
        {
            double area = (side * height) / 2;
            return area;
        }

        static double CalculateAreaOfSquare(double side)
        {
            double area = side * side;
            return area;
        }

        static double CalculateAreaOfRectangle(double width, double height)
        {
            double area = width * height;
            return area;
        }

        static double CalculateAreaOfCircle(double radius)
        {
            double area = Math.PI * Math.Pow(radius, 2);
            return area;
        }
    }
}

