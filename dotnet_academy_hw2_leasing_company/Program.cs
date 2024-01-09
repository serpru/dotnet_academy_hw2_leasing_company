using dotnet_academy_hw2_leasing_company.models.utils;
using dotnet_academy_hw2_leasing_company.models.Vehicles;
using dotnet_academy_hw2_leasing_company.models.VehicleWarehouse;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace dotnet_academy_hw2_leasing_company
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string jsonString = File.ReadAllText(".\\data\\vehicles.json");
                JSONVehicleWrapper loadedVehicles = JsonSerializer.Deserialize<JSONVehicleWrapper>(jsonString)!;

                VehicleWarehouse vehicleWarehouse = new VehicleWarehouse(loadedVehicles.Vehicles);

                Console.WriteLine("All vehicles in warehouse");
                PrintResults(vehicleWarehouse.Vehicles);

                var fordVehicles = vehicleWarehouse.FilterByBrand("Ford").ToList();
                Console.WriteLine("\nFilter by Ford brand");
                PrintResults(fordVehicles);

                var exceededTenure = vehicleWarehouse.FilterByExceededTenure("M1");
                Console.WriteLine("\nFilter by exceeded tenure");
                PrintResults(exceededTenure);

                var totalValue = vehicleWarehouse.GetTotalVehiclesValue();

                Console.WriteLine($"\nTotal vehicle value: {totalValue.ToString("0.##")}");

                string prefferedBrand = "Ford";
                string prefferedColor = "#992348";
                var preferredVehicles = vehicleWarehouse.FilterByBrandAndColor(prefferedBrand, prefferedColor);
                Console.WriteLine($"\nFilter by preference: {prefferedBrand}, {prefferedColor}");
                PrintResults(preferredVehicles);

                var closeToMaintenance = vehicleWarehouse.FilterByCloseToMaintenance();
                Console.WriteLine("\nVehicles close to required maintenance");
                PrintResults(closeToMaintenance);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error has occured");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Closing program...");
            }
        }

        static void PrintResults(IEnumerable<IVehicle>vehicleCollection)
        {
            var vehicleList = vehicleCollection.ToList();
            Console.WriteLine("ID\t Brand\t\t Model\t Reg num\t Color\t\t Price\t\t Mileage\t Production year\t Service start date\t Vehicle type");
            foreach (var vehicle in vehicleList)
            {
                Console.WriteLine($"{vehicle.ID}\t {vehicle.Brand}\t\t {vehicle.Model}\t {vehicle.RegistrationNumber}\t {ColorTranslator.FromHtml(vehicle.Color).Name}\t {vehicle.Price}\t {vehicle.Mileage}\t\t {vehicle.ProductionYear}\t\t\t {vehicle.ServiceStartTime.ToShortDateString()}\t\t {vehicle.GetType().Name}");
            }
        }
    }
}