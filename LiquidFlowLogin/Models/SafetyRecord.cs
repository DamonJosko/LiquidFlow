using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class SafetyRecord
    {
        // Public integer variable for SafetyRecordID
        // Primary key
        public int SafetyRecordID { get; set; }

        // Public string variable for SafetyRecordDetail
        public string SafetyRecordDetail { get; set; }

        // Collection of this namespace for RocketPropellant
        public ICollection<RocketPropellant> RocketPropellants { get; set; }
    }
}
