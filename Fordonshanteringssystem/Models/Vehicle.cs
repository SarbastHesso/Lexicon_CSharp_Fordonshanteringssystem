using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonshanteringssystem.Models
{
    public abstract class Vehicle
    {
        private string brand;
        private string model;
        private int year;
        private double weight;

        public string Brand 
        { 
            get => brand;  
            set 
            {
                if (value.Length < 2 || value.Length > 20 )
                    throw new ArgumentException("Märke måste vara mellan 2 och 20 tecken");
                brand = value;
            } 
        }
        public string Model 
        {
            get => model; 
            set 
            {
                if (value.Length < 2 || value.Length > 20 )
                    throw new ArgumentException("Model måste vara mellan 2 och 20 tecken");
                model = value;
            } 
        }

        public int Year
        {
            get => year; 
            set
            {
                if (value < 1886 || value > DateTime.Now.Year)
                    throw new ArgumentException("År måste vara mellan 1886 och nuvarande år.");
                year = value;
            }
        }
        public double Weight
        {
            get => weight; 
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Vikt måste vara ett positivt värde.");
                weight = value;
            }
        }

        public Vehicle(string brand, string model, int year, double weight)
        {
            Brand = brand;
            Model = model;  
            Year = year;
            Weight = weight;
        }

        public abstract void StartEngine();
        public abstract string Stats();

        public override string ToString()
        {
            return $"{Brand} {Model} ({Year}) - {weight} kg";
        }
    }
}
