using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }


        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double SurfaceArae()
        {
            double result = 2 * 
                (
                this.Length * this.Width
                + this.Length * this.Height
                + this.Width * this.Height
                );

            return result;
        }

        public double LateralSurfaceArae()
        {
            double result = 2 * (this.Length * this.Height + this.Width * this.Height);

            return result;
        }

        public double Volume()
        {
            double result = this.Length * this.Width * this.Height;

            return result;
        }
    }
}
