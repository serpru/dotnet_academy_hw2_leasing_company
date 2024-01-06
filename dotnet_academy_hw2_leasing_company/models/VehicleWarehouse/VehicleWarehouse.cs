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
        public ICollection<Vehicle> FilterByExceededTenure(string model)
        {
            var result = Vehicles
                .Where(v => v.Model.Equals(model))
                .Where(v => v.HasExceededTenure().Equals(true));
            throw new NotImplementedException();
        }
        public decimal GetTotalVehiclesValue() { throw new NotImplementedException(); }
        public ICollection<Vehicle> FilterByBrandOrColor(string brandName, Color color) { throw new NotImplementedException(); }
        public ICollection<Vehicle> FilterByCloseToMaintenance() { throw new NotImplementedException(); }

    }
}
