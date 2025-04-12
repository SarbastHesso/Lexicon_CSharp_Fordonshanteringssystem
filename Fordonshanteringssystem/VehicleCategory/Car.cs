using Fordonshanteringssystem.Interfaces;
using Fordonshanteringssystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.VehicleCategory
{
    public class Car: Vehicle, ICleanable
    {
        public Car(string brand, string model, int year, double weight)
            : base(brand, model, year, weight) { }

        public void Clean()
        {
            Console.WriteLine($"{Brand} {Model} is being cleaned.");
        }
        public override void StartEngine()
        {
            Console.WriteLine("Bilens motor startas");
        }

        public override string Stats()
        {
            return $"{Brand} {Model}, {Year} - Vikt: {Weight} kg - Bilmodell";
        }
    }
}
