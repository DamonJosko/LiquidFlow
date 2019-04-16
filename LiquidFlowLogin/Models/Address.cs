using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// Namespaces always have public access and this cant be changed
// A namespace is used to hold a set of objects as well as organise the code elements
// A namespace can have multipul classes declared inside
// This namespace is set to "LiquidFlow.Models" which contains all of the classes
namespace LiquidFlowLogin.Models
{   
    // Public class called Address
    // Public is an access modifier of the lowest access level
    // There are no restrictions when accessing a public type or type memeber
    // A class is used to define an object, this class is called 'Address'
    // A class can also have multipul classes inside, they are known as a nested class
    public class Address
    {
        // Public integer variable for AddressID
        // Primary key
        // Int is a variable type that allows any integer between -2,147,483,648 to 2,147,483,647 and is from the System.int32
        // Get and set are both accessor methods
        // Get and set are used to return the values accosiated with that variable
        // As this is the most simple case of get and set (only being used to set and retrieve a variable), C# auto-compiler has been used 
        public int AddressID { get; set; }

        // Public integer variable for HouseNumber
        public int HouseNumber { get; set; }

        // Foreign key for StreetName
        // The purpose of this Foreign Key is to define the relationship between StreetNameID in this class and in the StreetName class
        // StreetNameID in the StreetName class will be a Primary key
        // By ensuring all Foreign keys have a single relationship then 'Referential Integrity' will be maintained
        public int StreetNameID { get; set; }
        public StreetName StreetName { get; set; }

        // Foreign key for City
        public int CityID { get; set; }
        public City City { get; set; }

        // Foreign key for CountyState
        public int CountyStateID { get; set; }
        public CountyState CountyState { get; set; }

        // Foreign key for ZIP
        public int ZIPID { get; set; }
        public ZIP ZIP { get; set; }

        // Foreign key for Country
        public int CountryID { get; set; }
        public Country Country { get; set; }
        
        // Collection of this namespace for CompanyAddresses
        // ICollection is from the System.Collections.Generic namespace
        // This namespace allows for the creation of strongly typed collections with better safety and performance
        public ICollection<CompanyAddress> CompanyAddresses { get; set; }

        // Collection of this namespace for StaffAddresses
        public ICollection<StaffAddress> StaffAddresses { get; set; }
    }
}
