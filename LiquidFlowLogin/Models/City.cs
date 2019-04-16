using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// This namespace is set to "LiquidFlow.Models" which contains all of the classes
namespace LiquidFlowLogin.Models
{
    // Public class called City
    public class City
    {
        // Public integer variable for CityID
        // Primary key
        public int CityID { get; set; }

        // Public string variable for CityName
        // A string is a series of unicode charaters
        public string CityName { get; set; }

        // Collection of this namespace for Addresses
        public ICollection<Address> Addresses { get; set; }
    }
}
