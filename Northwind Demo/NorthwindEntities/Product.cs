using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEntities
{
    // This class will be mapped directly to the Products table in NorthwindExtended.
    public class Product
    {
        public int ProductID { get; set; }          // ProductID    int     PRIMARY KEY     NOT NULL,
        public string ProductName { get; set; }     // ProductName  nvarchar(40)            NOT NULL,
        public int? SupplierID { get; set; }        // SupplierID   int                         NULL,
        public int? CategoryID { get; set; }        // CategoryID   int                         NULL,
        public string QuantityPerUnit { get; set; } // QuantityPerUnit  nvarchar(20)            NULL,
        public decimal? UnitPrice { get; set; }     // UnitPrice    money                       NULL,
        public short? UnitsInStock { get; set; }    // UnitsInStock smallint                    NULL,
        public short? UnitsOnOrder { get; set; }    // UnitsOnOrder smallint                    NULL,
        public short? ReorderLevel { get; set; }    // ReorderLevel smallint                    NULL,
        public bool Discontinued { get; set; }      // Discontinued bit                     NOT NULL
    }
}
