using Fordonshanteringssystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.VehicleCategory
{
    public class Motorcycle: Vehicle
    {
        public bool HasSidecar { get; set; }

        public Motorcycle(string brand, string model, int year, double weight, bool hasSidecar)
            : base(brand, model, year, weight)
        {
            HasSidecar = hasSidecar;
        }

        public override void StartEngine()
        {
            Console.WriteLine("Motorcykelns motor startas!");
        }

        public override string Stats()
        {
            return $"{Brand} {Model}, {Year} - Vikt: {Weight} kg - Motorcykel med sidovagn: {HasSidecar}";
        }

    }
}
