using Fordonshanteringssystem.Interfaces;
using Fordonshanteringssystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.VehicleCategory
{
    public class Truck : Vehicle, ICleanable
    {
        public double CargoCapacity { get; set; }

        public Truck(string brand, string model, int year, double weight, double cargoCapacity)
            : base(brand, model, year, weight)
        {
            CargoCapacity = cargoCapacity;
        }

        public void Clean()
        {
            Console.WriteLine($"{Brand} {Model} truck is being cleaned.");
        }

        public override void StartEngine()
        {
            Console.WriteLine("Lastbilens motor startas");
        }

        public override string Stats()
        {
            return $"{Brand} {Model}, {Year} - Vikt: {Weight} kg - Lastbil med lastkapacitet: {CargoCapacity} kg";
        }
    }
}
