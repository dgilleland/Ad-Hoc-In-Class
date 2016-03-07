using NorthwindEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindSystem.DAL
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext() : base("NorthwindExtended") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
