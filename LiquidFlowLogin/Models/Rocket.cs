using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class Rocket
    {
        // Public integer variable for RocketID
        // Priamry key
        public int RocketID { get; set; }

        // Foreign key for the RocketName
        public int RocketNameID { get; set; }
        public RocketName RocketName { get; set; }

        // Public string variable for RocketModel
        public string RocketModel { get; set; }

        // Foreign key for the company
        public int CompanyID { get; set; }
        public Company Company { get; set; }

        // Foreign key for the RocketPropellant
        public int RocketPropellantID { get; set; }
        public RocketPropellant RocketPropellant { get; set; }

        // Public decimal variable for PropellantMaxCapacity
        public decimal PropellantMaxCapacity { get; set; }

        // Public decimal variable for PropellantCurrentCapacity
        public decimal PropellantCurrentCapacity { get; set; }
    }
}
