using System;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length; 

            private set
            {
                ValidateParameter(nameof(this.Length), value);

                this.length = value; 
            }
        }

        public double Width
        {
            get => this.width; 

            private set 
            {
                ValidateParameter(nameof(this.Width), value);

                this.width = value; 
            }
        }

        public double Height
        {
            get => this.height; 
            
            private set 
            {
                ValidateParameter(nameof(this.Height), value);

                this.height = value; 
            }
        }

        public double SurfaceArea() => ((2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height));

        public double LateralSurfaceArea() => ((2 * this.Length * this.Height) + (2 * this.Width * this.Height));

        public double Volume() => (this.Length * this.Width * this.Height);

        private void ValidateParameter(string variableName, double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{variableName} cannot be zero or negative.");
            }
        }
    }
}
