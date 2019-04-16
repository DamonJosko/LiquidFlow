using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class StaffAddress
    {
        // Foreign key for Staff
        // Composite key
        public int StaffID { get; set; }
        public Staff Staff { get; set; }

        // Foreign key for Address
        // Composite key
        public int AddressID { get; set; }
        public Address Address { get; set; }
    }
}
