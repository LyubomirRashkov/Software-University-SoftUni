using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            double courses = Math.Ceiling (numberOfPeople * 1.0 / elevatorCapacity);

            Console.WriteLine(courses);
        }
    }
}
