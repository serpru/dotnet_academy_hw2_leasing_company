using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dotnet_academy_hw2_leasing_company.models.Vehicles
{
    internal class PassengerVehicle : Vehicle
    {
        [JsonConstructor]
        public PassengerVehicle(int ID, string Brand, string Color, string Model, int ProductionYear, decimal Price, string RegistrationNumber, DateTime ServiceStartTime, double Mileage = 0, double LeaseCostMultiplier = 1.0)
            : base(ID, Brand, Color, Model, ProductionYear, Price, RegistrationNumber, ServiceStartTime, Mileage, LeaseCostMultiplier)
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
        public decimal CalculateRentalCost(DateTime tripStartDate, DateTime tripEndDate, double travelDistance, double userRating)
        {
            throw new NotImplementedException();
        }
    }
}
