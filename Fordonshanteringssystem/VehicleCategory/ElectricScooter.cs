using Fordonshanteringssystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.VehicleCategory
{
    public class ElectricScooter: Vehicle
    {
        public double BatteryRange { get; set; }

        public ElectricScooter(string brand, string model, int year, double weight, double batteryRange)
            : base(brand, model, year, weight)
        {
            BatteryRange = batteryRange;
        }

        public override void StartEngine()
        {
            Console.WriteLine("El-scooterns motor startas");
        }

        public override string Stats()
        {
            return $"{Brand} {Model}, {Year} - Vikt: {Weight} kg - Elektrisk scooter med räckvidd: {BatteryRange} km";
        }
    }
}
