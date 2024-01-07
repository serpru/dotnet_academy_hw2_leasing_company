using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_academy_hw2_leasing_company.models.Vehicles
{
    internal class CargoVehicle : Vehicle
    {
        public CargoVehicle(int id, string brand, Color color, string model, int prodYear, decimal price, string registrationNumber, DateTime serviceStartTime, double mileage = 0, double leaseCostMultiplier = 1) : base(id, brand, color, model, prodYear, price, registrationNumber, serviceStartTime, mileage, leaseCostMultiplier)
        {
            _yearsInServiceLimit = 15;
            _mileageLimit = 1000000;
            _maintenanceThreshold = 15000;
            _valueDropPercentage = 0.07;
        }

        public override double DistanceLeftToMaintenance()
        {
            return _maintenanceThreshold - (Mileage % _maintenanceThreshold);
        }
        public override decimal GetCurrentValue()
        {
            var years = DateTime.Now.Year - ProductionYear;
            var result = Price;
            for (int i = 0; i < years; i++)
            {
                result = result - (result * (decimal)_valueDropPercentage);
            }
            return result;
        }
        public override bool HasExceededTenure()
        {
            var isTimeExceeded = ServiceStartTime.AddYears(_yearsInServiceLimit) < DateTime.Now;
            var isMileageExceeded = Mileage > _mileageLimit;
            return isTimeExceeded || isMileageExceeded;
        }
    }
}
