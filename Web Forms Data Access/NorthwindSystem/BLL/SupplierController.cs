using NorthwindEntities;
using NorthwindSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindSystem.BLL
{
    public class SupplierController
    {
        public List<Supplier> ListAllSuppliers()
        {
            using (var context = new NorthwindContext())
            {
                var allSuppliers = context.Suppliers;
                return allSuppliers.ToList();
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
            throw new NotImplementedException();
        }
        public int UpdateSupplier(Supplier item)
        {
            throw new NotImplementedException();
        }
        public int DeleteSupplier(int SupplierId)
        {
            throw new NotImplementedException();
        }
    }
}
