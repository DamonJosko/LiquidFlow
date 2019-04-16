using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// This namespace is set to "LiquidFlow.Models" which contains all of the classes
namespace LiquidFlowLogin.Models
{
    // Public class called CompanyAddess
    public class CompanyAddress
    {
        // Foreign key for Company
        public int CompanyID { get; set; }
        public Company Company { get; set; }

        // Foreign key for Address
        public int AddressID { get; set; }
        public Address Address { get; set; }
    }
}
