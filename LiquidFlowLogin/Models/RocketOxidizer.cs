using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class RocketOxidizer
    {
        // Public integer variable for RocketOxidizerID
        // Primary key
        public int RocketOxidizerID { get; set; }

        // Public string varibale for OxidizerName
        public string OxidizerName { get; set; }

        // Public decimal variable OxidizerAmount
        public decimal OxidizerAmount { get; set; }

        // Public decimal variable for OxidizerPrice
        public decimal OxidizerPrice { get; set; }

        // Public decimal varibale for BuyCost
        public decimal BuyCost { get; set; }

        // Collection of this namespace for RocketPropellant
        public ICollection<RocketPropellant> RocketPropellants { get; set; }
    }
}
