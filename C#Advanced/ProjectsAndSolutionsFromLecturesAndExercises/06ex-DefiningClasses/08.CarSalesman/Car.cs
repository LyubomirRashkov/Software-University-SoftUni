using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine(Engine.ToString());

            if (Weight == 0)
            {
                sb.AppendLine("  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {Weight}");
            }

            if (Color == null)
            {
                sb.AppendLine("  Color: n/a");
            }
            else
            {
                sb.AppendLine($"  Color: {Color}");
            }

            string output = sb.ToString().TrimEnd();

            return output;
        }
    }
}
