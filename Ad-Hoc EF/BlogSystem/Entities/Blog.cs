using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Entities
{
    public class BlogContext : DbContext // needs using System.Data.Entity;
    {
        public BlogContext()
            : base("MyBlog")
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
    public class BlogController
    {
        public List<Blog> ListBlogs()
        {
            using (var context = new BlogContext())
            {
                return context.Blogs.ToList();
            }
        }
    }
    public class Blog
    {
        public int BlogID { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class Article
    {
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
