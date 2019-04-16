using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class RocketFuel
    {
        // Public integer variable for RocketFuelID
        // Primary key
        public int RocketFuelID { get; set; }

        // Public string variable for FuelName
        public string FuelName { get; set; }

        // Foreign key for FuelType
        public int FuelTypeID { get; set; }
        public FuelType FuelType { get; set; }

        // Public decimal variable for FuelAmount
        public decimal FuelAmount { get; set; }

        // Public decimal variable for FuelPrice
        public decimal FuelPrice { get; set; }
        
        // Public decimal variable for BuyCost
        public decimal BuyCost { get; set; }

        // Collection of this namespace for RocketPropellant
        public ICollection<RocketPropellant> RocketPropellants { get; set; }
    }
}
