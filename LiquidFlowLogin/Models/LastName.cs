using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class LastName
    {
        // Public integer for LastNameID
        // Primary key
        public int LastNameID { get; set; }
        public string LName { get; set; }
        
        // Collection of this namespace for StaffMemebers
        public ICollection<Staff> StaffMembers { get; set; }
    }
}
