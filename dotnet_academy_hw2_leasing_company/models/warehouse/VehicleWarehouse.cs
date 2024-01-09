using dotnet_academy_hw2_leasing_company.models.Vehicles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_academy_hw2_leasing_company.models.VehicleWarehouse
{
    internal class VehicleWarehouse
    {
        public ICollection<IVehicle> Vehicles { get; set; }
        public VehicleWarehouse(ICollection<IVehicle> vehicles)
        {
            Vehicles = vehicles;
        }
        public IEnumerable<IVehicle> FilterByBrand(string brandName)
        {
            var result = Vehicles.Where(v => v.Brand.Equals(brandName));
            return result;
        }
        public IEnumerable<IVehicle> FilterByExceededTenure(string model)
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
        public IEnumerable<IVehicle> FilterByBrandAndColor(string brandName, string color) 
        { 
            var matchedVehicles = Vehicles.Where(v => v.Brand.Equals(brandName) && v.Color.Equals(color));
            return matchedVehicles;
        }
        public IEnumerable<IVehicle> FilterByCloseToMaintenance() 
        {
            var matchedVehicles = Vehicles.Where(v => v.DistanceLeftToMaintenance() <= 1000);
            return matchedVehicles;
        }
    }
}
