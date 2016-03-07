using NorthwindEntities;
using NorthwindSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindSystem.BLL
{
    public class CategoryController
    {
        public List<Category> ListAllCategories()
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.ToList();
            }
        }
        public Category LookupCategory(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.Find(categoryid);
            }
        }
        public int AddCategory(Category item)
        {
            throw new NotImplementedException();
        }
        public int UpdateCategory(Category item)
        {
            throw new NotImplementedException();
        }
        public int DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
