using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class Staff
    {
        // Public integer variable for StaffID
        // Primary key
        public int StaffID { get; set; }

        // Foreign key for FirstName
        public int FirstNameID { get; set; }
        public FirstName FirstName { get; set; }

        // Foreign key for LastName
        public int LastNameID { get; set; }
        public LastName LastName { get; set; }

        // Collection of this namespace for StaffAddress
        public ICollection<StaffAddress> StaffAddresses { get; set; }
    }
}