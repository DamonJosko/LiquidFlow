using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class FirstName
    {
        // Public integer variable for FirstNameID
        // Primary key
        public int FirstNameID { get; set; }
        public string FName { get; set; }
        
        // Collection of this namespace for StaffMembers
        public ICollection<Staff> StaffMembers { get; set; }
    }
}
