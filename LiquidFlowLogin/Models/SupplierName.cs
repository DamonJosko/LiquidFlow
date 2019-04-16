using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class SupplierName
    {
        // Public integer variable for SupplierNameID
        // Primary key
        public int SupplierNameID { get; set; }

        // Public string variable for SupplierName
        public string SupName { get; set; }

        // Collection of this namespace for RocketPropellant
        // The change of supplier was due to C# assuming that there was a loop, even though there wasnt
        // As a result, denormalisation was necessary
        public ICollection<RocketPropellant> RocketPropellants { get; set; }
    }
}
