using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_academy_hw2_leasing_company.models.Vehicles
{
    public abstract class Vehicle
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public Color Color { get; set; }
        public string Model { get; set; }
        public DateOnly ProductionYear { get; set; }
        public decimal Price { get; set; }
        public string RegistrationNumber { get; set; }
        public double Mileage { get; set; }
        public DateTime ServiceStartTime { get; set; }

        protected Vehicle(int id, string brand, Color color, string model, DateOnly prodYear, decimal price,
            string registrationNumber, DateTime serviceStartTime, double mileage = 0)
        {
            ID = id;
            Brand = brand;
            Color = color;
            Model = model;
            ProductionYear = prodYear;
            Price = price;
            RegistrationNumber = registrationNumber;
            ServiceStartTime = serviceStartTime;
            Mileage = mileage;
        }

        public abstract decimal GetCurrentValue();

    }
}
