using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// This namespace is set to "LiquidFlow.Models" which contains all of the classes
namespace LiquidFlowLogin.Models
{
    // Public class called Company
    public class Company
    {
        // Public integer variable for CompanyID
        // Primary key
        public int CompanyID { get; set; }

        // Public string variable for CompanyName
        public string CompanyName { get; set; }
        
        // Collection of this namespace for Rockets
        public ICollection<Rocket> Rockets { get; set; }

        // Collection of this namespace for CompanyAddresses
        public ICollection<CompanyAddress> CompanyAddresses { get; set; }
    }
}
