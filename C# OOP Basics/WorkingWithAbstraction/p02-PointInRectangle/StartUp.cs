using System;
using System.Linq;

namespace PointInRectangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //“<topLeftX> <topLeftY> <bottomRightX> <bottomRightY>
            string[] coordinates = Console.ReadLine().Split();
            int topLeftX = int.Parse(coordinates[0]);
            int topLeftY = int.Parse(coordinates[1]);
            int bottomRightX = int.Parse(coordinates[2]);
            int bottomRightY = int.Parse(coordinates[3]);

            Point topLeftPoint = new Point(topLeftX, topLeftY);
            Point bottomRightPoint = new Point(bottomRightX, bottomRightY);

            Rectangle rectangle = new Rectangle(topLeftPoint, bottomRightPoint);

            int countOfPoints = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < countOfPoints; counter++)
            {
                int[] coordinate = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                Point point = new Point(coordinate[0], coordinate[1]);

                bool isInRectangle = rectangle.Contains(point);

                Console.WriteLine(isInRectangle);
            }
        }
    }
}
