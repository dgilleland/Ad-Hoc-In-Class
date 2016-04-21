using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindSystem.BLL;
using NorthwindEntities;

public partial class Staffing_AddEditTerritories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            // This will happen once on each brand new visit to the page
            // Populate the Territories Drop Down List control
            StaffingController bll = new StaffingController();
            var data = bll.ListTerritories();
            TDropDown.DataSource = data;
            TDropDown.DataTextField = "TerritoryDescription";
            TDropDown.DataValueField = "TerritoryID";
            TDropDown.DataBind();
        }
    }
}