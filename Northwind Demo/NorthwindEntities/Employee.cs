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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Key]
using System.ComponentModel.DataAnnotations.Schema; // [Table], [NotMapped], required Entity Framework
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEntities
{

    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [NotMapped]
        public string FormalName
        { get { return LastName + ", " + FirstName; } }

        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        // Since Region is always uppercase in the database, 
        // I will handle that here in the entity.
        private string _Region; // private field
        public string Region // public property
        {
            get { return _Region; }
            set 
            {
                if (value != null)
                    _Region = value.ToUpper();
                else
                    _Region = null;
            }
        }

        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoMimeType { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }
        public DateTime LastModified { get; set; }
    }
}
