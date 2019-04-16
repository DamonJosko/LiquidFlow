using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LiquidFlowLogin.Models;

// ApplicationDbContext extends IdentityDbContext
// IdentityDbContext refers to Microsoft.EntityFrameworkCore and provides an internal database connection with identity authentication
namespace LiquidFlowLogin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // The TContext is ApplicationDbContext
        // This makes ApplicationDbContext available for injection from the service container
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            // Base refers the the base class, the class in which ApplicationDbContect derives from
            // This would be the IdentityDbContext namespace
            : base(options)
        {
        }

        // This maps the class of Address to a database table and view
        // DbSet is from the Entity Framework 6 and represents an entity that can create, read, update and delete
        public DbSet<Address> Addresses { get; set; }

        // This maps the class of City to a database table and view
        public DbSet<City> Cities { get; set; }

        // This maps the class of Company to a database table and view
        public DbSet<Company> Companies { get; set; }

        // This maps the class of CompanyAddress to a database table and view
        public DbSet<CompanyAddress> CompanyAddresses { get; set; }

        // This maps the class of Country to a database table and view
        public DbSet<Country> Countries { get; set; }

        // This maps the class of CountyState to a database table and view
        public DbSet<CountyState> CountyStates { get; set; }

        // This maps the class of DeliveryVehicle to a database table and view
        public DbSet<DeliveryVehicle> DeliveryVehicles { get; set; }

        // This maps the class of FirstName to a database table and view
        public DbSet<FirstName> FirstNames { get; set; }

        // This maps the class of FuelType to a database table and view
        public DbSet<FuelType> FuelTypes { get; set; }

        // This maps the class of LastName to a database table and view
        public DbSet<LastName> LastNames { get; set; }

        // This maps the class of Mixture to a database table and view
        public DbSet<Mixture> Mixtures { get; set; }

        // This maps the class of Order to a database table and view
        public DbSet<Order> Orders { get; set; }

        // This maps the class of OrderRocketPropellant to a database table and view
        public DbSet<OrderRocketPropellant> OrderRocketPropellants { get; set; }

        // This maps the class of Rocket to a database table and view
        public DbSet<Rocket> Rockets { get; set; }

        // This maps the class of RocketFuel to a database table and view
        public DbSet<RocketFuel> RocketFuels { get; set; }

        // This maps the class of RocketName to a database table and view
        public DbSet<RocketName> RocketNames { get; set; }

        // This maps the class of RocketOxidizer to a database table and view
        public DbSet<RocketOxidizer> RocketOxidizers { get; set; }

        // This maps the class of RocketPropellant to a database table and view
        public DbSet<RocketPropellant> RocketPropellants { get; set; }

        // This maps the class of SafetyRecord to a database table and view
        public DbSet<SafetyRecord> SafetyRecords { get; set; }

        // This maps the class of Staff to a database table and view
        public DbSet<Staff> StaffMemebers { get; set; }

        // This maps the class of StaffAddress to a database table and view
        public DbSet<StaffAddress> StaffAddresses { get; set; }

        // This maps the class of Status to a database table and view
        public DbSet<Status> Statuses { get; set; }

        // This maps the class of StreetName to a database table and view
        public DbSet<StreetName> StreetNames { get; set; }

        // This maps the class of SupplierName to a database table and view
        public DbSet<SupplierName> SupplierNames { get; set; }

        // This maps the class of ZIP to a database table and view
        public DbSet<ZIP> ZIPs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // This binds the ComapnyAddress.CompanyID and CompanyAddress.AddressID to a foreign key constraint
            modelBuilder.Entity<CompanyAddress>()
                .HasKey(c => new { c.CompanyID, c.AddressID });

            // This binds the OrderRocketPropellant.OrderID and OrderRocketPropellant.RocketPropellantID to a foreign key constraint
            modelBuilder.Entity<OrderRocketPropellant>()
                .HasKey(c => new { c.OrderID, c.RocketPropellantID });

            // This binds the StaffAddress.StaffID and StaffAddress.AddressID to a foreign key constraint
            modelBuilder.Entity<StaffAddress>()
                .HasKey(c => new { c.StaffID, c.AddressID });

        }

    }
}
