using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            CarsByRegistrationNumber = new Dictionary<string, Car>();

            Capacity = capacity;
        }

        private Dictionary<string, Car> carsByRegistrationNumber;

        private int capacity;

        public Dictionary<string, Car> CarsByRegistrationNumber 
        {
            get 
            {
                return carsByRegistrationNumber;
            }
            set 
            {
                carsByRegistrationNumber = value;
            } 
        }

        public int Capacity 
        {
            get 
            {
                return capacity;
            }
            set 
            {
                capacity = value;
            } 
        }

        public int Count 
        {
            get
            {
                return carsByRegistrationNumber.Count;
            } 
            set 
            {
                Count = carsByRegistrationNumber.Count;
            } 
        }

        public string AddCar(Car car) 
        {
            if (CarsByRegistrationNumber.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else
            {
                if (CarsByRegistrationNumber.Count == Capacity)
                {
                    return "Parking is full!";
                }
                else
                {
                    CarsByRegistrationNumber.Add(car.RegistrationNumber, car);

                    return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
                }
            }
        }

        public string RemoveCar(string registrationNumber) 
        {
            if (!CarsByRegistrationNumber.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                CarsByRegistrationNumber.Remove(registrationNumber);

                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return CarsByRegistrationNumber[registrationNumber];
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers) 
        {
            foreach (string registrationNumber in RegistrationNumbers)
            {
                if (CarsByRegistrationNumber.ContainsKey(registrationNumber))
                {
                    CarsByRegistrationNumber.Remove(registrationNumber);
                }
            }
        }
    }
}
