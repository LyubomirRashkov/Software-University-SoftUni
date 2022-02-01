using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"  {Model}:");
            sb.AppendLine($"    Power: {Power}");

            if (Displacement == 0)
            {
                sb.AppendLine("    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {Displacement}");
            }

            if (Efficiency == null)
            {
                sb.AppendLine("    Efficiency: n/a");
            }
            else
            {
                sb.AppendLine($"    Efficiency: {Efficiency}");
            }

            string output = sb.ToString().TrimEnd();

            return output;
        }
    }
}
