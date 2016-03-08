using NorthwindEntities;
using NorthwindSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindSystem.BLL
{
    public class ProductController
    {
        public List<Product> ListAllProducts()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }
        public Product LookupProduct(int Productid)
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.Find(Productid);
            }
        }
        public int AddProduct(Product item)
        {
            throw new NotImplementedException();
        }
        public int UpdateProduct(Product item)
        {
            throw new NotImplementedException();
        }
        public int DeleteProduct(int ProductId)
        {
            throw new NotImplementedException();
        }
    }
}
