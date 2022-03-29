using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius 
        {
            get => this.radius;

            private set 
            {
                this.radius = value;
            } 
        }

        public override double CalculateArea() => (Math.PI * this.Radius * this.Radius);

        public override double CalculatePerimeter() => (2 * Math.PI * this.Radius);

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
