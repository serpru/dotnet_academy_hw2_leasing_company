using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dotnet_academy_hw2_leasing_company.models.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        protected double _mileageLimit;
        protected int _yearsInServiceLimit;
        protected double _maintenanceThreshold;
        protected double _valueDropPercentage;
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("brand_name")]
        public string Brand { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("lease_cost_multiplier")]
        public double LeaseCostMultiplier { get; set; }
        [JsonPropertyName("production_year")]
        public int ProductionYear { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("registration_number")]
        public string RegistrationNumber { get; set; }
        [JsonPropertyName("mileage")]
        public double Mileage { get; set; }
        [JsonPropertyName("service_start_time")]
        public DateTime ServiceStartTime { get; set; }
        [JsonConstructor]
        protected Vehicle(int ID, string Brand, string Color, string Model, int ProductionYear, decimal Price,
            string RegistrationNumber, DateTime ServiceStartTime, double Mileage = 0, double LeaseCostMultiplier = 1.0)
        {
            this.ID = ID;
            this.Brand = Brand;
            this.Color = Color;
            this.Model = Model;
            this.ProductionYear = ProductionYear;
            this.Price = Price;
            this.RegistrationNumber = RegistrationNumber;
            this.ServiceStartTime = ServiceStartTime;
            this.Mileage = Mileage;
            this.LeaseCostMultiplier = LeaseCostMultiplier;
        }
        public abstract decimal GetCurrentValue();
        public abstract bool HasExceededTenure();
        public abstract double DistanceLeftToMaintenance();
    }
}
