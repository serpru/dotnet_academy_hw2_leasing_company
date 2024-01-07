using dotnet_academy_hw2_leasing_company.models.Vehicles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_academy_hw2_leasing_company.models.VehicleWarehouse
{
    internal class VehicleWarehouse
    {
        public ICollection<Vehicle> Vehicles { get; set; }
        public VehicleWarehouse() { Vehicles = new List<Vehicle>(); }
        public VehicleWarehouse(ICollection<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }
        public IEnumerable<Vehicle> FilterByBrand(string brandName)
        {
            var result = Vehicles.Where(v => v.Brand.Equals(brandName));
            return result;
        }
        public IEnumerable<Vehicle> FilterByExceededTenure(string model)
        {
            var result = Vehicles
                .Where(v => v.Model.Equals(model))
                .Where(v => v.HasExceededTenure().Equals(true));
            return result;
        }
        public decimal GetTotalVehiclesValue() 
        {
            decimal totalValue = 0;
            foreach (var v in Vehicles)
            {
                totalValue += v.GetCurrentValue();
            }
            return totalValue;
        }
        public IEnumerable<Vehicle> FilterByBrandAndColor(string brandName, Color color) 
        { 
            var matchedVehicles = Vehicles.Where(v => v.Brand.Equals(brandName) && v.Color.Equals(color));
            return matchedVehicles;
        }
        public IEnumerable<Vehicle> FilterByCloseToMaintenance() 
        {
            var matchedVehicles = Vehicles.Where(v => v.DistanceLeftToMaintenance() <= 1000);
            return matchedVehicles;
        }

    }
}
