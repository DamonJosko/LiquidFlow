using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Models
{
    public class OrderRocketPropellant
    {
        // Foreign key for Order
        // Composite key
        public int OrderID { get; set; }
        public Order Order { get; set; }

        // Foreign key for RocketPropellant
        // Composite key
        public int RocketPropellantID { get; set; }
        public RocketPropellant RocketPropellant { get; set; }

        // Public decimal variable for OrderRocketPropellantAmount
        public decimal OrderRocketPropellantAmount { get; set; }

        // Public decimal variable for OrderRocketPropellantCost
        public decimal OrderRocketPropellantCost { get; set; }
    }
}
