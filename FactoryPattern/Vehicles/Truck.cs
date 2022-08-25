using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Vehicles
{
    internal class Truck : IVehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; } = 2023;
        public bool isDrivable { get; set; }
        public void PrintDetails()
        {
            Console.WriteLine($"Make: {Make}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Inspection Passed: {isDrivable}");
            VehicleFactory.AddSpaces();

            Honk();
            Drive();
            VehicleFactory.AddSpaces();
        }
        public void Drive()
        {
            if (isDrivable == true)
            {
                Console.WriteLine("The truck is driving!");
            }
            else Console.WriteLine("*sputter* Ah! It won't start!");
        }
        public void Honk()
        {
            Console.WriteLine("WEE WOO! WEE WOO!");
        }

    }
}
