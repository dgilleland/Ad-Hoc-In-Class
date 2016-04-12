using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NorthwindEntities
{
    [Table("EmployeeTerritories")]
    public class EmployeeTerritory
    {
        [Key, Column(Order = 0)]
        public int EmployeeID { get; set; }
        [Key, Column(Order = 1)]
        public string TerritoryID { get; set; }
    }
}
