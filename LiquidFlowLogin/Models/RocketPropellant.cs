using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class RocketPropellant
    {
        // Public integer variable for RocketPropellantID
        // Primary key
        public int RocketPropellantID { get; set; }

        // Foreign key for RocketFuel
        public int RocketFuelID { get; set; }
        public RocketFuel RocketFuel { get; set; }

        // Foreign key for RocketOxidizer
        public int RocketOxidizerID { get; set; }
        public RocketOxidizer RocketOxidizer { get; set; }

        // Foreign key for Mixture
        public int MixtureID { get; set; }
        public Mixture Mixture { get; set; }

        // Foreign key for SupplierName
        public int SupplierNameID { get; set; }
        public SupplierName SupplierName { get; set; }

        // Foreign key for SafetyRecord
        public int SafetyRecordID { get; set; }
        public SafetyRecord SafetyRecord { get; set; }

        // Collection of this namespace for Rocket
        public ICollection<Rocket> Rockets { get; set; }
    }
}
