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
                MessagePanel.CssClass = "alert alert-danger alert-dismissible";
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
        Category.Items.Insert(0, new ListItem("[select a category]"));
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
        Supplier.Items.Insert(0, new ListItem("[select a supplier]"));
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
                MessagePanel.CssClass = "alert alert-success alert-dismissible";
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
    
    protected void ClearForm_Click(object sender, EventArgs e)
    {
        // Reset all the controls on the form
        CurrentProducts.SelectedIndex = 0;
        Supplier.SelectedIndex = 0;
        Category.SelectedIndex = 0;
        ProductID.Text = "";
        ProductName.Text = "";
        QtyPerUnit.Text = "";
        UnitPrice.Text = "";
        InStock.Text = "";
        OnOrder.Text = "";
        ReorderLevel.Text = "";
        Discontinued.Checked = false;
    }

    protected void AddProduct_Click(object sender, EventArgs e)
    {
        // TODO: Do any validation
        try
        {
            // Create a Product object and fill it with the data from the form
            Product item = GetProductFromUser();

            // Send the Product object to the BLL
            NorthwindController controller = new NorthwindController();
            int newItemId = controller.AddProduct(item); // my bad ;)

            // Give the user some feedback
            PopulateProductsDropDown(); // because we have a new product for the list
            CurrentProducts.SelectedValue = newItemId.ToString();
            ProductID.Text = newItemId.ToString();

            MessageLabel.Text = "Product added";
            MessagePanel.CssClass = "alert alert-success alert-dismissable";
            MessagePanel.Visible = true;

        }
        catch (Exception ex)
        {
                MessageLabel.Text = ex.Message;
                MessagePanel.CssClass = "alert alert-danger alert-dismissable";
                MessagePanel.Visible = true;
        }
    }

    private Product GetProductFromUser()
    {
        Product item = new Product();
        item.ProductName = ProductName.Text;
        // Nullable supplier/category from the DropDownList controls
        int temp;
        if (int.TryParse(Supplier.SelectedValue, out temp)) // If I can convert the SelectedValue to an int...
            item.SupplierID = temp;
        if (int.TryParse(Category.SelectedValue, out temp))
            item.CategoryID = temp;
        // Nullable quantity per unit from a TextBox
        // - a couple of things to note: It's not quite sufficient to just see if the text is null or empty.
        //   It's possible that the user entered in only spaces, and we want to strip out leading and trailing
        //   spaces from their input.
        if (!string.IsNullOrWhiteSpace(QtyPerUnit.Text))
            item.QuantityPerUnit = QtyPerUnit.Text.Trim(); // remove leading/trailing white space

        // Get the unit price
        decimal money;
        if (decimal.TryParse(UnitPrice.Text, out money))
            item.UnitPrice = money;

        // Get the instock/onorder/reorder values
        short smallNumber;
        if (short.TryParse(InStock.Text, out smallNumber))
            item.UnitsInStock = smallNumber;
        if (short.TryParse(OnOrder.Text, out smallNumber))
            item.UnitsOnOrder = smallNumber;
        if (short.TryParse(ReorderLevel.Text, out smallNumber))
            item.ReorderLevel = smallNumber;

        // Discontinued is a simple true/false (not nullable)
        item.Discontinued = Discontinued.Checked;
        return item;
    }

    protected void UpdateProduct_Click(object sender, EventArgs e)
    {
        // TODO: Do any validation
        int id;
        if (int.TryParse(ProductID.Text, out id)) // If there is a Product ID
        {
            try
            {
                // Create a Product object and fill it with the data from the form
                Product item = GetProductFromUser(); // Everything but the ProductId
                item.ProductID = id; // The id from when they did the Lookup

                // Send the Product object to the BLL
                NorthwindController controller = new NorthwindController();
                controller.UpdateProduct(item);

                // Give the user some feedback
                PopulateProductsDropDown();
                CurrentProducts.SelectedValue = id.ToString();
                MessageLabel.Text = item.ProductName + " was successfully updated";
                MessagePanel.CssClass = "alert alert-success alert-dismissible";
                MessagePanel.Visible = true;

            }
            catch (Exception ex)
            {
                MessageLabel.Text = "Error: " + ex.Message;
                MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                MessagePanel.Visible = true;
            }
        }
        else
        {
            MessageLabel.Text = "Please lookup a product before clicking the Update button.";
            MessagePanel.CssClass = "alert alert-info alert-dismissible";
            MessagePanel.Visible = true;

        }
    }

    protected void DeleteProduct_Click(object sender, EventArgs e)
    {

    }
}