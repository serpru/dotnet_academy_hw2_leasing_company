using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dotnet_academy_hw2_leasing_company.models.Vehicles
{
    [JsonDerivedType(typeof(PassengerVehicle), typeDiscriminator: "passenger_vehicle")]
    [JsonDerivedType(typeof(CargoVehicle), typeDiscriminator: "cargo_vehicle")]
    internal interface IVehicle
    {
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

        public decimal GetCurrentValue();
        public bool HasExceededTenure();
        public double DistanceLeftToMaintenance();
    }
}
