using Fordonshanteringssystem.Errors;
using Fordonshanteringssystem.Handlers;
using Fordonshanteringssystem.Interfaces;
using Fordonshanteringssystem.Models;
using Fordonshanteringssystem.VehicleCategory;

namespace Fordonshanteringssystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
                new Car("BMW", "X5", 2020, 2100),
                new Car("Volvo", "V60", 2022, 1700),
                new Truck("Volvo", "FH16", 2020, 8000, 12000),
                new Motorcycle("Harley Davidson", "Sportster", 2019, 250, true),
                new ElectricScooter("Xiaomi", "M365", 2021, 12, 30)
            };
            VehicleHandler handler = new VehicleHandler();
            List<SystemError> errors = new List<SystemError>()
            {
                new EngineFailureError(),
                new BrakeFailureError(),
                new TransmissionError()
            };


            try
            {

                handler.ListVehicles(vehicles);

                try
                {
                    vehicles.Add(handler.CreateVehicle("BMW", "X1", 2015, 1650, "Car"));
                    handler.UpdateVehicle(vehicles[1], weight: 1400);
                    Console.WriteLine("Fordonet uppdaterades");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Fel vid uppdatering: " + ex.Message);
                }

                handler.ListVehicles(vehicles);

                Console.WriteLine("=== Felmeddelanden ===");
                foreach (SystemError error in errors)
                {
                    Console.WriteLine(error.ErrorMessage());
                }

                Console.WriteLine("======== Loop genom vehicles med metoder ========");
                foreach (Vehicle vehicle in vehicles)
                {
                    Console.WriteLine(vehicle.Stats());
                    vehicle.StartEngine();
                    if (vehicle is ICleanable cleanableVehicle)
                    {
                        cleanableVehicle.Clean();
                    }
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Fel vid skapande av fordon: " + ex.Message);
            }
        }
    }
}
