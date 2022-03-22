using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            Console.WriteLine(new String('*', this.width));

            for (int i = 2; i <= this.height - 1; i++)
            {
                for (int j = 1; j <= this.width; j++)
                {
                    if (j == 1 || j == this.width)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine(new String('*', this.width));
        }
    }
}
