using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// This namespace is set to "LiquidFlow.Models" which contains all of the classes
namespace LiquidFlowLogin.Models
{
    // Public class called DeliveryVehicle
    public class DeliveryVehicle
    {
        // Public integer variable for DeliveryVehicleID
        // Primary Key
        public int DeliveryVehicleID { get; set; }

        // Public string variable for VehicleRegistration
        public string VehicleRegistration { get; set; }

        // Foreign key for Status
        public int StatusID { get; set; }
        public Status Status { get; set; }

        // Collection of this namespace for Orders
        public ICollection<Order> Orders { get; set; }
        }

}
