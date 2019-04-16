using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class ZIP
    {
        // Public integer variable for ZIPID
        // Primary key
        public int ZIPID { get; set; }

        // Public string variable for ZIPCode
        public string ZIPCode { get; set; }

        // Collection of this namespace for Address
        public ICollection<Address> Addresses { get; set; }
    }
}
