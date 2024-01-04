using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_academy_hw2_leasing_company.models.utils
{
    //  TODO create pseudo database for models/coefficients/brands
    internal static class ModelDict
    {
        static readonly Dictionary<string, (double, string)> Models = new Dictionary<string, (double, string)>()
        { 
            {"modelOpel1", (2.5, "Opel") },
            {"modelToyota1", (1.5, "Toyota") },
            {"modelOpel2", (1.0, "Opel") }
        };
    }
}
