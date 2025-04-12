using Fordonshanteringssystem.Models;
using Fordonshanteringssystem.VehicleCategory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Handlers
{
    public class VehicleHandler
    {
        public Vehicle CreateVehicle(string brand, string model, int year, double weight, string vehicleType)
        {
            if (vehicleType == "Car")
            {
                return new Car(brand, model, year, weight);
            }
            else if (vehicleType == "Truck")
            {
                return new Truck(brand, model, year, weight, 12000);
            }
            else if (vehicleType == "Motorcycle")
            {
                return new Motorcycle(brand, model, year, weight, true); 
            }
            else if (vehicleType == "ElectricScooter")
            {
                return new ElectricScooter(brand, model, year, weight, 30); 
            }
            else
            {
                throw new ArgumentException("Unknown vehicle type");
            }
        }

        public Vehicle UpdateVehicle(Vehicle vehicle, string? brand=null, string? model = null, int? year = null, double? weight = null)
        {
            if (brand != null) vehicle.Brand = brand;
            if (model != null) vehicle.Model = model;
            if (year != null) vehicle.Year = year.Value;
            if (weight != null) vehicle.Weight = weight.Value;

            return vehicle;
        }

        public void ListVehicles(List<Vehicle> vehicles)
        {
            Console.WriteLine("=== Fordonslista ===");
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }
    }
}
