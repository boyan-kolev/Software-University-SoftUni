using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_RectangleIntersection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int numberOfRectangles = int.Parse(input[0]);
            int numberOfIntersection = int.Parse(input[1]);
            List<Rectangle> rectangles = new List<Rectangle>();

            for (int counter = 0; counter < numberOfRectangles; counter++)
            {
                string[] tokens = Console.ReadLine().Split();
                string id = tokens[0];
                double width = double.Parse(tokens[1]);
                double height = double.Parse(tokens[2]);
                double x = double.Parse(tokens[3]);
                double y = double.Parse(tokens[4]);

                Rectangle rectangle = new Rectangle(id, width, height, x, y);

                rectangles.Add(rectangle);
            }

            for (int counter = 0; counter < numberOfIntersection ; counter++)
            {
                string[] ids = Console.ReadLine().Split();
                string id1 = ids[0];
                string id2 = ids[1];

                Rectangle rectangle1 = rectangles.Where(x => x.Id == id1).FirstOrDefault();
                Rectangle rectangle2 = rectangles.Where(x => x.Id == id2).FirstOrDefault();

                bool check = rectangle1.IsIntersection(rectangle2);
                if (check)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
