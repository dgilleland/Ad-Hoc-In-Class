using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEntities;
using NorthwindSystem.DAL;

namespace NorthwindSystem.BLL
{
    public class StaffingController
    {
        #region Territory CRUD methods
        public List<Territory> ListTerritories()
        {
            using(var context = new NorthwindContext())
            {
                return context.Territories.ToList();
            }
        }
        public string AddTerritory(Territory item)
        {
            using(var context = new NorthwindContext())
            {
                var result = context.Territories.Add(item);
                context.SaveChanges();
                return result.TerritoryID;
            }
        }
        #endregion
    }
}
