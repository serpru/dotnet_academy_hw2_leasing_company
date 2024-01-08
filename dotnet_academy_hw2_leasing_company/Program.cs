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
            //var vehicles = new List<IVehicle>()
            //{
            //    new PassengerVehicle(1, "Ford", "#32a852", "M1", 1995, 15000.20m, "DL123456", new DateTime(2019,1,1), 2000.50),
            //    new PassengerVehicle(2, "Nissan", "#32a852", "M1", 1995, 12040.50m, "DL15721", new DateTime(2023,10,25), 154500),
            //    new PassengerVehicle(3, "Toyota", "#32a852", "T5", 1996, 28000.00m, "DL123572", new DateTime(2019,8,11), 30000),
            //    new CargoVehicle(4, "Nissan", "#32a852", "MC1", 1989, 100000.00m, "DL923211", new DateTime(2019,5,24), 150000),
            //    new CargoVehicle(5, "Ford", "#32a852", "MC1", 1990, 120000.00m, "DL923531", new DateTime(2018,1,22), 110350),
            //    new CargoVehicle(6, "Opel", "#32a852", "MC50", 2020, 155000.00m, "DL911532", new DateTime(2020,11,22), 74500),
            //};

            //JSONVehicleWrapper jsonVehicles = new JSONVehicleWrapper(vehicles);

            //var vehiclesSerialized = JsonSerializer.Serialize<JSONVehicleWrapper>(jsonVehicles, options);
            //File.WriteAllText(@".\\data\\saved.json", vehiclesSerialized);

            string jsonString = File.ReadAllText(".\\data\\saved.json");
            JSONVehicleWrapper loadedVehicles = JsonSerializer.Deserialize<JSONVehicleWrapper>(jsonString)!;

            VehicleWarehouse vehicleWarehouse = new VehicleWarehouse(loadedVehicles.Vehicles);

            var fordVehicles = vehicleWarehouse.FilterByBrand("Ford").ToList();
            Console.WriteLine("Filter by Ford brand");
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

        static void PrintResults(IEnumerable<IVehicle>vehicleCollection)
        {
            var vehicleList = vehicleCollection.ToList();
            Console.WriteLine("ID\t Brand\t\t Model\t Reg num\t Color\t\t Price\t\t Mileage\t Production year\t Service start date");
            foreach (var vehicle in vehicleList)
            {
                Console.WriteLine($"{vehicle.ID}\t {vehicle.Brand}\t\t {vehicle.Model}\t {vehicle.RegistrationNumber}\t {ColorTranslator.FromHtml(vehicle.Color).Name}\t {vehicle.Price}\t {vehicle.Mileage}\t\t {vehicle.ProductionYear}\t\t\t {vehicle.ServiceStartTime.ToShortDateString()}");
            }
        }
    }
}