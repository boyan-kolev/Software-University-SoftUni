using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get { return width; }
            private set { width = value; }
        }

        public int Height
        {
            get { return height; }
             private set { height = value; }
        }


        public void Draw()
        {
            Console.WriteLine(new string('*', this.Width));

            for (int row = 0; row < this.Height - 2; row++)
            {
                Console.WriteLine($"*{(new string(' ', this.Width - 2))}*");
            }

            Console.WriteLine(new string('*', width));
        }
    }
}
