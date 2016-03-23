using NorthwindEntities;   // for the appropriate Entity classes
using NorthwindSystem.BLL; // for the NorthwindController class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Purchasing_AddEditProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MessagePanel.Visible = false; // Hide the panel to start with each time
        if (!IsPostBack) // on the initial GET of the page
        {
            // Since I am communicating with the "back end" that happens to call the database,
            // I should really put all these kinds of calls inside of a try/catch block.
            try
            {
                PopulateProductsDropDown();
                PopulateSupplierDropDown();
                PopulateCategoryDropDown();
            }
            catch (Exception ex)
            {
                MessageLabel.Text = "ERROR: " + ex.Message;
                // get the inner exception....
                Exception inner = ex;
                // this next statement drills down on the details of the exception
                while (inner.InnerException != null)
                    inner = inner.InnerException;
                if (inner != ex)
                    MessageLabel.Text += "<blockquote>" + inner.Message + "</blockquote>";
                MessagePanel.CssClass = "alert alert-danger alert-dismissable";
                MessagePanel.Visible = true;
            }
        }
    }

    private void PopulateCategoryDropDown()
    {
        NorthwindController controller = new NorthwindController();
        List<Category> categories = controller.ListAllCategories();
        Category.DataSource = categories;
        Category.DataTextField = "CategoryName";
        Category.DataValueField = "CategoryID";
        Category.DataBind();
        // Let's insert a couple of options at the top of the drop-down
        Category.Items.Insert(0, new ListItem("[select a category]", "-1"));
        Category.Items.Insert(1, new ListItem("[no category]", "")); // because Product.CategoryID is nullable
    }

    private void PopulateSupplierDropDown()
    {
        NorthwindController controller = new NorthwindController();
        List<Supplier> suppliers = controller.ListAllSuppliers();
        Supplier.DataSource = suppliers;
        Supplier.DataTextField = "CompanyName";
        Supplier.DataValueField = "SupplierID";
        Supplier.DataBind();
        // Let's insert a couple of options at the top of the drop-down
        Supplier.Items.Insert(0, new ListItem("[select a supplier]", "-1"));
        Supplier.Items.Insert(1, new ListItem("[no supplier]", "")); // because Product.SupplierID is nullable
    }

    private void PopulateProductsDropDown()
    {
        // We can populate some controls such as DropDownLists with data
        // Populate CurrentProducts with all the products in the database
        NorthwindController controller = new NorthwindController();
        // controller is a NorthwindController object
        List<Product> products = controller.ListAllProducts();
        // products is a List<Product> object
        CurrentProducts.DataSource = products;
        // CurrentProducts is a DropDownList
        CurrentProducts.DataTextField = "ProductName"; // The property of the Product class to display
        CurrentProducts.DataValueField = "ProductID";
        CurrentProducts.DataBind(); // Populate the DropDownList
        CurrentProducts.Items.Insert(0, "[select a product]");
    }

    protected void ShowProductDetails_Click(object sender, EventArgs e)
    {
        int searchId;
        if(CurrentProducts.SelectedIndex == 0)
        {
            MessageLabel.Text = "Please select a product from the dropdown before clicking [Show Product Details]";
            MessagePanel.Visible = true;
            MessagePanel.CssClass = "alert alert-info alert-dismissible";
        }
        else
        {
            try
            {
                searchId = int.Parse(CurrentProducts.SelectedValue);
                NorthwindController controller = new NorthwindController();
                Product foundProduct = controller.GetProduct(searchId);

                // Unpacking the found product into the form
                ProductID.Text = foundProduct.ProductID.ToString();
                ProductName.Text = foundProduct.ProductName;
                // Select the supplier/category for the found product
                Supplier.SelectedValue = foundProduct.SupplierID.ToString();
                Category.SelectedValue = foundProduct.CategoryID.ToString();
                // Other values that are displayed in text boxes
                QtyPerUnit.Text = foundProduct.QuantityPerUnit;
                UnitPrice.Text = foundProduct.UnitPrice.ToString();
                InStock.Text = foundProduct.UnitsInStock.ToString();
                OnOrder.Text = foundProduct.UnitsOnOrder.ToString();
                ReorderLevel.Text = foundProduct.ReorderLevel.ToString();
                // Set the checkbox for the found product's Discontinued flag
                Discontinued.Checked = foundProduct.Discontinued;

                MessageLabel.Text = "Product details found";
                MessagePanel.CssClass = "alert alert-success alert-dismissable";
                MessagePanel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
                MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                MessagePanel.Visible = true;
            }
        }
    }
}