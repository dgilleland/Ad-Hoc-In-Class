using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Namespace usings for the Entity classes and the Data Access Layer
using NorthwindEntities;
using NorthwindSystem.DAL;
using System.Data.SqlClient;
// Namespace needed for using Controllers with ObjectDataSource controls
using System.ComponentModel;

namespace NorthwindSystem.BLL
{
    // This class is the public access into our system/application
    // that will be used by the website.
    [DataObject] // This class can be used to get objects for DataBound controls
    public class InventoryPurchasingController
    {
        #region Countries
        public List<CountryName> ListAllCountries()
        {
            using (var context = new NorthwindContext())
            {
                var result = context.Database.SqlQuery<CountryName>("Countries_List");
                return result.ToList();
            }
        }
        #endregion

        #region Products CRUD
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

        public int AddProduct(Product item)
        {
            using (NorthwindContext dbContext = new NorthwindContext())
            {
                // FYI: If I had a Guid property that I needed to create a value for
                //      when adding the item (hint, hint: think of your lab), I could do this:
                // item.rowguid = Guid.NewGuid();

                Product newItem = dbContext.Products.Add(item);
                dbContext.SaveChanges();
                return newItem.ProductID;
            }
        }

        public void UpdateProduct(Product item)
        {
            using (NorthwindContext dbContext = new NorthwindContext())
            {
                // At the BLL level of processing the Update request,
                // I am going to set the item's LastModified date before
                // I do the update.
                item.LastModified = DateTime.Now;

                // The following approach will update the entire Product object
                // in the database.

                // Attach sets up a Product object that should match the
                // one we will need to update on the database
                var existing = dbContext.Entry(item);
                // Tell the dbContext that this object's data is modified
                existing.State = System.Data.Entity.EntityState.Modified;
                // Save the changes
                dbContext.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Products.Find(id);
                context.Products.Remove(existing);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)] // to Read objects
        public List<Product> GetProductsByCategory(int searchId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context // from the context of where I connect to the Db server...
                         .Database // access the database directly to ...
                           .SqlQuery<Product>("EXEC Products_GetByCategories @cat"
                                              , new SqlParameter("cat", searchId))
                             .ToList();
            }
        }
        #endregion

        #region Suppliers CRUD
        public List<Supplier> ListAllSuppliers()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Suppliers.ToList();
            }
        }

        public Supplier LookupSupplier(int Supplierid)
        {
            using (var context = new NorthwindContext())
            {
                return context.Suppliers.Find(Supplierid);
            }
        }

        public int AddSupplier(Supplier item)
        {
            using (NorthwindContext dbContext = new NorthwindContext())
            {
                Supplier newItem = dbContext.Suppliers.Add(item);
                dbContext.SaveChanges();
                return newItem.SupplierID;
            }
        }

        public void UpdateSupplier(Supplier item)
        {
            using (NorthwindContext dbContext = new NorthwindContext())
            {
                var existing = dbContext.Entry(item);
                // Tell the dbContext that this object's data is modified
                existing.State = System.Data.Entity.EntityState.Modified;
                // Save the changes
                dbContext.SaveChanges();
            }
        }

        public void DeleteSupplier(int SupplierId)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Suppliers.Find(SupplierId);
                context.Suppliers.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion

        #region Categories CRUD
        [DataObjectMethod(DataObjectMethodType.Select)] // method is for SELECT
        public List<Category> ListAllCategories()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Categories.OrderBy(item=>item.CategoryName).ToList();
                //                       \[scary] Lambda stuff [next term]/
            }
        }

        public Category LookupCategory(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.Find(categoryid);
            }
        }

        public int AddCategory(Category item)
        {
            using (NorthwindContext dbContext = new NorthwindContext())
            {
                Category newItem = dbContext.Categories.Add(item);
                dbContext.SaveChanges();
                return newItem.CategoryID;
            }
        }

        public void UpdateCategory(Category item)
        {
            using (NorthwindContext dbContext = new NorthwindContext())
            {
                var existing = dbContext.Entry(item);
                // Tell the dbContext that this object's data is modified
                existing.State = System.Data.Entity.EntityState.Modified;
                // Save the changes
                dbContext.SaveChanges();
            }
        }

        public void DeleteCategory(int categoryId)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Categories.Find(categoryId);
                context.Categories.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion

        #region SQL Injection Demo
        public List<Customer> FindCustomersSloppy(string p)
        {
            using(var context = new NorthwindContext())
            {
                string sql = "SELECT * FROM CUSTOMERS WHERE CompanyName LIKE '%" + p + "%'";
                var query = context.Database.SqlQuery<Customer>(sql);
                return query.ToList();
            }
        }

        public List<Customer> FindCustomersProper(string p)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
