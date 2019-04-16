using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class Mixture
    {
        // Public integer variable for MixtureID
        // Primary key
        public int MixtureID { get; set; }
        public string MixtureRatio { get; set; }

        // Collection of this namespace for RocketPropellants
        public ICollection<RocketPropellant> RocketPropellants { get; set; }
    }
}
