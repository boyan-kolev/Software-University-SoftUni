using System;
using System.Linq;
using System.Collections.Generic;

namespace _05_ClosestTwoPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<Point> points = new List<Point>();

            for (int i = 0; i < num; i++)
            {
                points.Add(ReadPoints());
            }

            double smallestDistance = double.MaxValue;
            List<Point> closestPoints = new List<Point>();

            for (int i = 0; i < num; i++)
            {
                for (int j = i + 1; j < num; j++)
                {
                    double distance = Distance(points[i], points[j]);

                    if (distance < smallestDistance)
                    {
                        smallestDistance = distance;
                        closestPoints.Clear();

                        closestPoints.Add(points[i]);
                        closestPoints.Add(points[j]);
                    }
                }
            }

            Console.WriteLine($"{smallestDistance:f3}");

            foreach (Point pairPoints in closestPoints)
            {
                Console.WriteLine($"({pairPoints.X}, {pairPoints.Y})");
            }

        }

        static Point ReadPoints()
        {
            int[] points = Console.ReadLine()
                .Split()
                .Select(p => int.Parse(p))
                .ToArray();

            int point1 = points[0];
            int point2 = points[1];

            return new Point(point1, point2);

        }

        static double Distance(Point point1, Point point2)
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

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
