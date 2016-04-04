using NorthwindEntities;
using NorthwindSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Purchasing_SearchProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            PopulateCategoryDropDown();
            PopulateSupplierDropDown();
        }
    }

    private void PopulateSupplierDropDown()
    {
        NorthwindController controller = new NorthwindController();
        List<Supplier> data = controller.ListAllSuppliers();
        SupplierDropDown.DataSource = data;
        SupplierDropDown.DataTextField = "CompanyName";
        SupplierDropDown.DataValueField = "SupplierID";
        SupplierDropDown.DataBind();
        SupplierDropDown.Items.Insert(0, "[select a supplier]");

    }

    private void PopulateCategoryDropDown()
    {
        NorthwindController controller = new NorthwindController();
        List<Category> data = controller.ListAllCategories();
        CategoryDropDown.DataSource = data;
        CategoryDropDown.DataTextField = "CategoryName";
        CategoryDropDown.DataValueField = "CategoryID";
        CategoryDropDown.DataBind();
        CategoryDropDown.Items.Insert(0, "[select a Category]");
    }

    protected void LookupByCategory_Click(object sender, EventArgs e)
    {
        // TODO: Validate their selection (NOT want .SelectedIndex == 0)
        PopulateGridView();        
    }
    private void PopulateGridView()
    {
        NorthwindController controller = new NorthwindController();
        int searchId = int.Parse(CategoryDropDown.SelectedValue);
        List<Product> data = controller.GetProductsByCategory(searchId);

        SearchResultsGridView.DataSource = data;
        SearchResultsGridView.DataBind();
    }
    protected void LookupBySupplier_Click(object sender, EventArgs e)
    {

    }
    protected void SearchResultsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SearchResultsGridView.PageIndex = e.NewPageIndex;
        PopulateGridView();
    }
}