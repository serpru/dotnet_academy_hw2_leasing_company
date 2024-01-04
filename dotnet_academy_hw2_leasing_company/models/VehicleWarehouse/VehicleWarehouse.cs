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
        public ICollection<Vehicle> ShowBrand(string brandName)
        {
            throw new NotImplementedException();
        }
        public ICollection<Vehicle> ShowExceededTenure()
        {
            throw new NotImplementedException();
        }
        public decimal GetTotalVehiclesValue() { throw new NotImplementedException(); }
        public ICollection<Vehicle> ShowPreferred(string brandName, Color color) { throw new NotImplementedException(); }
        public ICollection<Vehicle> ShowCloseToMaintenance() { throw new NotImplementedException(); }

    }
}
