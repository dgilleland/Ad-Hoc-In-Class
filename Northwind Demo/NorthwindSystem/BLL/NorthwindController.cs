using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Namespace usings for the Entity classes and the Data Access Layer
using NorthwindEntities;
using NorthwindSystem.DAL;

namespace NorthwindSystem.BLL
{
    // This class is the public access into our system/application
    // that will be used by the website.
    public class NorthwindController
    {
        public List<Product> ListAllProducts()
        {
            // This "using" statement is different than the "using" at the top of this file.
            // This "using" statement is to ensure that the connection to the database is properly closed after we are done.
            using (NorthwindContext context = new NorthwindContext())
            {
                System.Data.Entity.DbSet<Product> stuff = context.Products;
                List<Product> listedStuff = stuff.ToList();
                return listedStuff;
                //return context.Products.ToList();
            }
        }
    }
}
