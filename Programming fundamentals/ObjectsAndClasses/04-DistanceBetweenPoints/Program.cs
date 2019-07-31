using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_DistanceBetweenPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstPoint = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            int[] secondPoint = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            List<Point> points = new List<Point>();

            points.Add(new Point(firstPoint[0], firstPoint[1]));
            points.Add(new Point(secondPoint[0], secondPoint[1]));

            double distance = CalcDistance(points[0], points[1]);

            Console.WriteLine("{0:f3}", distance);

        }

        static double CalcDistance(Point point1 ,Point point2)
        {
            int sideA = Math.Abs(point1.X - point2.X);
            int sideB = Math.Abs(point1.Y - point2.Y);

            double sideAPow = Math.Pow(sideA, 2);
            double sideBPow = Math.Pow(sideB, 2);

            double distance = Math.Sqrt(sideAPow + sideBPow);

            return distance;
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x ,int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
