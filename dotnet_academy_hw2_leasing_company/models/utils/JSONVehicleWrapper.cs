using dotnet_academy_hw2_leasing_company.models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dotnet_academy_hw2_leasing_company.models.utils
{
    internal class JSONVehicleWrapper
    {
        [JsonPropertyName("vehicles")]
        public ICollection<IVehicle>? Vehicles { get; set; }
        public JSONVehicleWrapper(ICollection<IVehicle> vehicles)
        {
            Vehicles = vehicles;
        }
    }
}
