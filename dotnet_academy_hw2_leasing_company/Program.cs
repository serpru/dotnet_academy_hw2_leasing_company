using dotnet_academy_hw2_leasing_company.models.Vehicles;
using dotnet_academy_hw2_leasing_company.models.VehicleWarehouse;
using System.Drawing;

namespace dotnet_academy_hw2_leasing_company
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //  TODO initialize VehicleWarehouse with vehicles
            var vehicles = new List<Vehicle>()
            {
                new PassengerVehicle(1, "Ford", Color.Teal, "M1", 1995, 15000.20m, "DL123456", new DateTime(2019,1,1), 2000.50),
                new PassengerVehicle(2, "Ford", Color.Red, "M1", 1995, 12040.50m, "DL15721", new DateTime(2023,10,25), 154500),
                new PassengerVehicle(3, "Toyota", Color.Red, "T5", 1996, 28000.00m, "DL123572", new DateTime(2019,8,11), 30000),
                new CargoVehicle(4, "Ford", Color.Black, "MC1", 1989, 100000.00m, "DL923211", new DateTime(2019,5,24), 150000),
                new CargoVehicle(5, "Ford", Color.Blue, "MC1", 1990, 120000.00m, "DL923531", new DateTime(2018,1,22), 110350),
                new CargoVehicle(6, "Ford", Color.Red, "MC50", 2020, 155000.00m, "DL911532", new DateTime(2020,11,22), 74500),
            };

            VehicleWarehouse vehicleWarehouse = new VehicleWarehouse(vehicles);
            var fordVehicles = vehicleWarehouse.FilterByBrand("Ford").ToList();
            Console.WriteLine("Filter by Ford brand");
            PrintResults(fordVehicles);

            var exceededTenure = vehicleWarehouse.FilterByExceededTenure("M1");
            Console.WriteLine("Filter by exceeded tenure");
            PrintResults(exceededTenure);

            var totalValue = vehicleWarehouse.GetTotalVehiclesValue();
         
            Console.WriteLine($"Total vehicle value: {totalValue.ToString("0.##")}");

            var preferredVehicles = vehicleWarehouse.FilterByBrandAndColor("Ford", Color.Red);
            Console.WriteLine("Filter by preference: Ford, Red");
            PrintResults(preferredVehicles);

            var closeToMaintenance = vehicleWarehouse.FilterByCloseToMaintenance();
            Console.WriteLine("Vehicles close to required maintenance");
            PrintResults(closeToMaintenance);

        }

        static void PrintResults(IEnumerable<Vehicle>vehicleCollection)
        {
            var vehicleList = vehicleCollection.ToList();
            Console.WriteLine("ID\t Brand\t Model\t Reg num\t Color\t Price\t\t Mileage\t Production year\t Service start date");
            foreach (var vehicle in vehicleList)
            {
                Console.WriteLine($"{vehicle.ID}\t {vehicle.Brand}\t {vehicle.Model}\t {vehicle.RegistrationNumber}\t {vehicle.Color.Name}\t {vehicle.Price}\t {vehicle.Mileage}\t\t {vehicle.ProductionYear}\t\t\t {vehicle.ServiceStartTime}");
            }
        }
    }
}