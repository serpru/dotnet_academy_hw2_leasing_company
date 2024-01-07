using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_academy_hw2_leasing_company.models.Vehicles
{
    internal class PassengerVehicle : Vehicle
    {
        public PassengerVehicle(int id, string brand, Color color, string model, int prodYear, decimal price, string registrationNumber, DateTime serviceStartTime, double mileage = 0, double leaseCostMultiplier = 1.0) 
            : base(id, brand, color, model, prodYear, price, registrationNumber, serviceStartTime, mileage, leaseCostMultiplier)
        {
            _yearsInServiceLimit = 5;
            _mileageLimit = 100000;
            _maintenanceThreshold = 5000;
            _valueDropPercentage = 0.1;
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

        public override double DistanceLeftToMaintenance()
        {
            return _maintenanceThreshold - (Mileage % _maintenanceThreshold);
        }
    }
}
