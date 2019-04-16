using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// This namespace is set to "LiquidFlow.Models" which contains all of the classes
namespace LiquidFlowLogin.Models
{
    // Public class called CountyState
    public class CountyState
    { 
        // Public integer variable for CountyStateID
        // Primary key
        public int CountyStateID { get; set; }

        // Public integer variable for CountyName
        public int CountyName { get; set; }

        // Collection of this namespace for Addresses
        public ICollection<Address> Addresses { get; set; }
    }
}