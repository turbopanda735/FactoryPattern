using System.ComponentModel.DataAnnotations;

namespace FactoryPattern
{
    public static class Program
    {
        public static void Main()
        {
            var vehicle = VehicleFactory.AskForVehicle();

            Console.WriteLine(vehicle);

            var vehicle2 = VehicleFactory.AskForVehicle();

            Console.WriteLine(vehicle2);

            var vehicleLot = new List<IVehicle>() { vehicle, vehicle2 };

            foreach (var automobile in vehicleLot)
            {
                automobile.PrintDetails();
            }
        }
    }
}