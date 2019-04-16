using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// This namespace is set to "LiquidFlow.Models" which contains all of the classes
namespace LiquidFlowLogin.Models
{
    // Public class called Country
    public class Country
    {
        // Public integer variable for CountyID
        public int CountryID { get; set; }

        // Public string variable for CountyName
        public string CountyName { get; set; }

        // Collection of this namespace for Addresses
        public ICollection<Address> Addresses { get; set; }
    }
}
