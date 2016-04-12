using System;
// The Entity Framework (EF) is a library of classes that allow
// us to interact and exchange data from database tables into
// classes that we define in our application.
// If we create classes that mirror the structure of the 
// database tables, then we can create a "Context" class
// that mirrors the database as a whole.
// NorthwindContext <==> NorthwindExtended database
// Properties of NorthwindContext <==> tables in the database
// Properties of Entities <==> columns in a specific table
using System.Data.Entity; // From the EF, for DbContext class
using NorthwindEntities; // To reference our Entity classes

namespace NorthwindSystem.DAL
{
    // We declare the class as "internal" so that it cannot be used
    // from outside this project's DLL.
    internal class NorthwindContext : DbContext
    {
        // Name of connection string in web.config passed to the base class
        public NorthwindContext() : base("NW")
        {
            Database.SetInitializer<NorthwindContext>(null);
        }

        // Properties that map our entities to database tables
        // Notice how the name we choose for our property matches
        // the name of the database table we are mapping to.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
