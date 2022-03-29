using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            Shape rectangle = new Rectangle(5, 3);

            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.Draw());

            Shape circle = new Circle(8);

            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.Draw());
        }
    }
}
