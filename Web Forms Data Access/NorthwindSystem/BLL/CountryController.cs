using NorthwindEntities;
using NorthwindSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindSystem.BLL
{
    public class CountryController
    {
        public List<CountryName> ListAllCountries()
        {
            using(var context = new NorthwindContext())
            {
                var result = context.Database.SqlQuery<CountryName>("Countries_List");
                return result.ToList();
            }
        }
    }
}
