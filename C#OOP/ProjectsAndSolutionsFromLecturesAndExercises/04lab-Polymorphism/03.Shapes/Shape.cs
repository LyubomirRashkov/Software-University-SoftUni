﻿namespace Shapes
{
    public abstract class Shape
    {
        public virtual string Draw()
        {
            return "Drawing ";
        }

        public abstract double CalculatePerimeter();

        public abstract double CalculateArea();
    }
}
