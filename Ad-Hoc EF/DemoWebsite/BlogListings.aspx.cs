using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BlogListings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BlogSystem.Entities.BlogController controller = new BlogSystem.Entities.BlogController();
            var data = controller.ListBlogs();
            BlogDropDown.DataSource = data;
            BlogDropDown.DataTextField = "Owner";
            BlogDropDown.DataValueField = "BlogID";
            BlogDropDown.DataBind();
        }
    }
}