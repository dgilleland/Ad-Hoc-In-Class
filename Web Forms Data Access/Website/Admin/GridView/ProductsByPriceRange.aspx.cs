using NorthwindSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_GridView_ProductsByPriceRange : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            MinPriceValue.Text = string.Format("{0:C}", int.Parse(MinPrice.Text));
            MaxPriceValue.Text = string.Format("{0:C}", int.Parse(MaxPrice.Text));
        }
    }

    protected void MinPrice_TextChanged(object sender, EventArgs e)
    {
        MinPriceValue.Text = string.Format("{0:C}", int.Parse(MinPrice.Text));
    }

    protected void MaxPrice_TextChanged(object sender, EventArgs e)
    {
        MaxPriceValue.Text = string.Format("{0:C}", int.Parse(MaxPrice.Text));
    }
    protected void LookupProducts_Click(object sender, EventArgs e)
    {
        var controller = new ProductController();
        var results = controller.FindProductsByPriceRange(int.Parse(MinPrice.Text), int.Parse(MaxPrice.Text));
        FoundProducts.DataSource = results;
        FoundProducts.DataBind();
    }
}