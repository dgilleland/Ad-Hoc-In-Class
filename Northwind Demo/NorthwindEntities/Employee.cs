using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEntities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string FormalName
        { get { return LastName + ", " + FirstName; } }

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

    }
}
