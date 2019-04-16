using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class RocketName
    {
        // Public integer variable for RocketNameID
        // Primary key
        public int RocketNameID { get; set; }

        // Public string variable for the RocketName
        public string RName { get; set; }
        
        // Collection of this namespace for Rocket
        public ICollection<Rocket> Rockets { get; set; }
    }
}
