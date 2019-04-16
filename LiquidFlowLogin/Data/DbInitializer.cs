using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidFlowLogin.Data
{
    public class DbInitializer
    {
        // Static means that this line refers to the class, not the instance of the class
        // Void ensures that the method does not take any parameters, and doesnt return a value
        public static void Initialize(ApplicationDbContext context)
        {
            // EnsureCreated(); is from the Microsoft.EntityFramework namespace
            // This is used to check to see if a database exists, if it does then no action is taken, if it doesnt exist then all schema get created
            context.Database.EnsureCreated();
        }
    }
}
