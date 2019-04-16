using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class StreetName
    {
        // Public integer variable for StreetNameID
        // Primary key
        public int StreetNameID { get; set; }

        // Public string variable for StreetName
        public string StrName { get; set; }
        
        // Collection of this namespace for Address
        public ICollection<Address> Addresses { get; set; }
    }
}
