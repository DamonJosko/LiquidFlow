using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class Order
    {
        // Public integervariable for OrderID
        // Primary key
        public int OrderID { get; set; }

        // Public decimal variable for TotalOrderCost 
        public decimal TotalOrderCost { get; set; }

        // Public DateTime variable for OrderDate
        public DateTime OrderDate { get; set; }

        // Foreign key for DeliveryVehicle
        public int DeliveryVehicleID { get; set; }
        public DeliveryVehicle DeliveryVehicle { get; set; }

        // Collection of this namespace for OrderRocketPropellant
        public ICollection<OrderRocketPropellant> OrderRocketPropellants { get; set; }
    }
}
