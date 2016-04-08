using NorthwindEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HackMePlease : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void HackClick_Click(object sender, EventArgs e)
    {
        var controller = new NorthwindSystem.BLL.InventoryPurchasingController();
        List<Customer> result = controller.FindCustomersSloppy(CustName.Text);
        SearchResultGV.DataSource = result;
        SearchResultGV.DataBind();
    }
    protected void SafeClick_Click(object sender, EventArgs e)
    {
        var controller = new NorthwindSystem.BLL.InventoryPurchasingController();
        List<Customer> result = controller.FindCustomersProper(CustName.Text);
        SearchResultGV.DataSource = result;
        SearchResultGV.DataBind();
    }
}