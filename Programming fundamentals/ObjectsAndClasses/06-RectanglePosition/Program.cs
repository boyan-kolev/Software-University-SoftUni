using System;

namespace _06_RectanglePosition
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static bool IsInside(Rectangle rectangle)
        {

        }

        static int 
    }

    class Rectangle
    {
        public int left { get; set; }
        public int top { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public double right { get {return left + width; } }
        public double bottom { get {return top + height; } }
    }
}
