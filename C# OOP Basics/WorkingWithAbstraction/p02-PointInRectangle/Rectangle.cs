using System;
using System.Collections.Generic;
using System.Text;

namespace PointInRectangle
{
    class Rectangle
    {
        public Point TopLeftCorner { get; set; }
        public Point BottomRightCorner { get; set; }

        public Rectangle(Point topLeftCorner, Point bottomRightCorner)
        {
            TopLeftCorner = topLeftCorner;
            BottomRightCorner = bottomRightCorner; 
        }

        public bool Contains(Point point)
        {
            bool isInHorizontal = point.X >= TopLeftCorner.X && point.X <= BottomRightCorner.X;
            bool isInVertical = point.Y >= TopLeftCorner.Y && point.Y <= BottomRightCorner.Y;

            return isInHorizontal && isInVertical;
        }
    }
}
