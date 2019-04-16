using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class Status
    {
        // Public integer variable for StatusID
        // Primary key
        public int StatusID { get; set; }

        // Public string variable for StatusType
        public string StatusType { get; set; }

        // Collection of this namespace for DeliveryVehicle
        public ICollection<DeliveryVehicle> DeliveryVehicles { get; set; }
    }
}
