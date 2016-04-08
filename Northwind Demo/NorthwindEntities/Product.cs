/*  Mapping our C# Entities to Database Tables
 *      By default, the Entity Framework (EF) will use some "defaults" in mapping classes to database
 *  tables. For example, if the C# class is named "Employee" (singular), then Entity Framework will
 *  assume that the database table is called "Employees" (plural). Likewise, for the same Employee
 *  class, Entity Framework is going to look for a property in the class called either "ID" or 
 *  "EmployeeID" to represent the Primary Key column in the database table.
 *  
 *      We can override these default assumptions of Entity Framework by adding Annotations to
 *  our class and its properties. The following annotations are used in this code sample:
 *      - [Table("TableName")]  //  This annotation is placed right before the class declaration
 *                                  and tells EF to map this class to the TableName in the annotation.
 *      - [Key]                 //  This annotation is placed right before the property declaration
 *                                  in the class that is supposed to map to the Primary Key column
 *                                  in the table.
 *      - [NotMapped]           //  This annotation is placed before any property declaration in our class
 *                                  that does NOT have a corresponding column name in the database table.
 */

using System;
using System.ComponentModel.DataAnnotations; // for [Key]
using System.ComponentModel.DataAnnotations.Schema; // [Table]

namespace NorthwindEntities
{
    // This class will be mapped directly to the Products table in NorthwindExtended.
    [Table("Products", Schema = "dbo")]
    public class Product
    {
        [Key] // An attribute that "decorates" our property
        public int ProductID { get; set; }          // ProductID    int     PRIMARY KEY     NOT NULL,
        public string ProductName { get; set; }     // ProductName  nvarchar(40)            NOT NULL,
        public int? SupplierID { get; set; }        // SupplierID   int                         NULL,
        public int? CategoryID { get; set; }        // CategoryID   int                         NULL,
        public string QuantityPerUnit { get; set; } // QuantityPerUnit  nvarchar(20)            NULL,
        public decimal? UnitPrice { get; set; }     // UnitPrice    money                       NULL,
        public short? UnitsInStock { get; set; }    // UnitsInStock smallint                    NULL,
        public short? UnitsOnOrder { get; set; }    // UnitsOnOrder smallint                    NULL,
        public short? ReorderLevel { get; set; }    // ReorderLevel smallint                    NULL,
        public bool Discontinued { get; set; }      // Discontinued bit                     NOT NULL,
        public DateTime LastModified { get; set; }  // LastModified datetime                NOT NULL

        [NotMapped]
        public string ProductInfo
        {
            get
            {
                string info;
                if (!string.IsNullOrEmpty(QuantityPerUnit))
                    info = ProductName;
                else
                    info = string.Format("{0} ({1})", ProductName, QuantityPerUnit);
                return info;
            }
        }
    }
}
