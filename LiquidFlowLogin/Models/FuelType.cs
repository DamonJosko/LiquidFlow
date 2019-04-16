using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class FuelType
    {
        // Public integer variable for FuelTypeID
        // Primary key
        public int FuelTypeID { get; set; }
        public string FuelTypeName { get; set; }

        // Collection of this namespace for RocketFuels
        public ICollection<RocketFuel> RocketFuels { get; set; }
    }
}
