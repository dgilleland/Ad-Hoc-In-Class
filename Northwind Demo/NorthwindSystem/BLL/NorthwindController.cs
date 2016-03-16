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
            // The variable context is a NorthwindContext object
            // The NorthwindContext class represents a "virtual" database
            using (NorthwindContext context = new NorthwindContext())
            {
                // context.Products is a DbSet<Product>. It represents the Products table in the database
                System.Data.Entity.DbSet<Product> stuff = context.Products;

                List<Product> listedStuff = stuff.ToList();
                return listedStuff;
                //return context.Products.ToList();
            }
        }

        public Product GetProduct(int productId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.Find(productId);
            }
        }

        public List<Supplier> ListAllSuppliers()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Suppliers.ToList();
            }
        }
    }
}
