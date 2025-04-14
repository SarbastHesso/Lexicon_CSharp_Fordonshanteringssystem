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
            //Vilken typ bör en lista vara för att rymma alla fordonstyper?
            //    Det ska vara av typ Vehicle
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
                    //Vad händer om du försöker lägga till en Car i en lista av Motorcycle?
                    //vehicles.Add(handler.CreateVehicle("Harley Davidson", "Sportster", 2017, 350, true));
                    //No overload for method 'CreateVehicle' takes 6 arguments
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
                //Kommer du åt metoden Clean() från en lista med typen List<Vehicle>?
                //Vi kommer åt metoden bara om listan är ICleanable
                //Vad är fördelarna med att använda ett interface här istället för arv?
                //Det är flexibel, så vi kan använda det i klassarna vi vill
                
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
            Console.ReadKey();
        }
    }
}
