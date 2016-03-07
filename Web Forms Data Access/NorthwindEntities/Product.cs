using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindEntities
{
    public class Product
    {
        #region fields and properties
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public double? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        #endregion
        #region constructors
        public Product()
        {
        }
        public Product(int productid,
                       string productname,
                       int? supplierid,
                       int? categoryid,
                       string quantityperunit,
                       double? unitprice,
                       short? unitsinstock,
                       short? unitsonorder,
                       short? reorderlevel,
                       bool discontinued)
        {
            ProductID = productid;
            ProductName = productname;
            SupplierID = supplierid;
            CategoryID = categoryid;
            QuantityPerUnit = quantityperunit;
            UnitPrice = unitprice;
            UnitsInStock = unitsinstock;
            UnitsOnOrder = unitsonorder;
            ReorderLevel = reorderlevel;
            Discontinued = discontinued;
        }
        #endregion
    }
}
