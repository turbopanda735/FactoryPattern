using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FactoryPattern.Vehicles;

namespace FactoryPattern
{
    public static class VehicleFactory
    {
        public static IVehicle AskForVehicle()
        {
            Console.WriteLine("What vehicle would you like?");
            
            var userInput = Console.ReadLine();
            var userVehicle = GetVehicle(userInput);

            bool validVehicle;
            do
            {
                var isDrivable = Inspection();
                if (isDrivable)
                    validVehicle = true;
                else
                {
                    Console.WriteLine("Let's see if we can get you a new inspector. I don't like that guy.");
                    AddSpaces();
                    validVehicle = false;
                }

            } while (!validVehicle);
            return userVehicle;
        }
        public static IVehicle GetVehicle(string userInput)
        {
            AddSpaces();
            var make = SetMake();
            AddSpaces();
            var model = SetModel();
            AddSpaces();

            switch (userInput.ToLower())
            {
                case "car":
                    Console.WriteLine("I like cars. You should take the train though.");
                    return new Car()
                    {
                        isDrivable = true,
                        Make = make,
                        Model = model
                    };
                case "truck":
                    Console.WriteLine("Nice choice. Don't drive it downtown.");
                    return new Truck()
                    {
                        isDrivable = true,
                        Make = make,
                        Model = model
                    };
                default:
                    Console.WriteLine("How about a car?");
                    return new Car()
                    {
                        isDrivable = true,
                        Make = make,
                        Model = model
                    };
            }
        }
        public static string SetMake()
        {
            Console.WriteLine("What make would you like? This is a Japanese factory. Valid makes are Subaru, Nissan, Toyota, and Honda.");
            var userInput = Console.ReadLine();

            switch (userInput.ToLower())
            {
                case "toyota":
                    return "toyota";
                case "nissan":
                    return "nissan";
                case "honda":
                    return "honda";
                case "subaru":
                    return "subaru";
                default:
                    Console.WriteLine("The most popular automobile maker in the US is Toyota. How about one of those?");
                    return "toyota";
            }
        }
        public static string SetModel()
        {
            Console.WriteLine("What model would you like?");
            return Console.ReadLine();
        }

        public static bool Inspection()
        {
            AddSpaces();
            Console.WriteLine("Ok, we are going to inspect the vehicle before it leaves the factory.");
            AddSpaces();

            var random = new Random();
            var driveChance = random.Next(1, 11);

            switch (driveChance)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    Console.WriteLine("Your vehicle is good to go. It's drivable.");
                    AddSpaces();
                    return true;
                case 6:
                case 7:
                case 8:
                    Console.WriteLine("Your vehicle had an issue but it's fine. I will mark your vehicle as driveable.");
                    AddSpaces();
                    return true;
                case 9:
                case 10:
                    Console.WriteLine("Sorry, we couldn't save your vehicle. It's not drivable.");
                    AddSpaces();
                    return false;
                default: return false;
            }
        }
        public static void AddSpaces()
        {
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
