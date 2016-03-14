using NorthwindEntities;
using NorthwindSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddEditProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                PopulateCurrentProductsDropdown();
                PopulateSuppliersDropdown();
                PopulateCategoriesDropdown();
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
                MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                MessagePanel.Visible = true;
            }
        }
    } // end of Page_Load

    private void PopulateCurrentProductsDropdown()
    {
        // Populate CurrentProducts drop-down
        ProductController controller = new ProductController();
        List<Product> products = controller.ListAllProducts();
        CurrentProducts.DataSource = products;
        CurrentProducts.DataTextField = "ProductName";
        CurrentProducts.DataValueField = "ProductID";
        CurrentProducts.DataBind();
        CurrentProducts.Items.Insert(0, "[select a product]");
    }

    private void PopulateSuppliersDropdown()
    {
        // Populate Supplier drop-down
        SupplierController controller = new SupplierController();
        List<Supplier> Suppliers = controller.ListAllSuppliers();
        this.Supplier.DataSource = Suppliers;
        this.Supplier.DataTextField = "CompanyName";
        this.Supplier.DataValueField = "SupplierID";
        this.Supplier.DataBind();
        this.Supplier.Items.Insert(0, new ListItem("[no supplier]", ""));
    }

    private void PopulateCategoriesDropdown()
    {
        // Populate Category drop-down
        CategoryController controller = new CategoryController();
        List<Category> categories = controller.ListAllCategories();
        this.Category.DataSource = categories;
        this.Category.DataTextField = "CategoryName";
        this.Category.DataValueField = "CategoryID";
        this.Category.DataBind();
        this.Category.Items.Insert(0, new ListItem("[no category]", ""));
    }

    protected void ShowProductDetails_Click(object sender, EventArgs e)
    {
        if (CurrentProducts.SelectedIndex == 0)
        {
            MessageLabel.Text = "Select a product before clicking 'Show Product Details'";
        }
        else
        {
            try
            {
                // Lookup the Product object
                ProductController controller = new ProductController();
                int showID = int.Parse(CurrentProducts.SelectedValue);
                Product info = controller.LookupProduct(showID);

                // Display the Product details
                ProductID.Text = info.ProductID.ToString();
                ProductName.Text = info.ProductName;
                Supplier.Text = info.SupplierID.ToString();
                Category.Text = info.CategoryID.ToString();
                QtyPerUnit.Text = info.QuantityPerUnit;
                UnitPrice.Text = info.UnitPrice.ToString();
                InStock.Text = info.UnitsInStock.ToString();
                OnOrder.Text = info.UnitsOnOrder.ToString();
                ReorderLevel.Text = info.ReorderLevel.ToString();
                Discontinued.Checked = info.Discontinued;

                MessageLabel.Text = "Product details found.";
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
                MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                MessagePanel.Visible = true;
            }
        }
    }

    protected void AddProduct_Click(object sender, EventArgs e)
    {
        if (IsValid)
            try
            {
                Product item = new Product();
                item.ProductName = ProductName.Text;
                if (!string.IsNullOrEmpty(Supplier.SelectedValue))
                    item.SupplierID = int.Parse(Supplier.SelectedValue);
                if (!string.IsNullOrEmpty(Category.SelectedValue))
                    item.CategoryID = int.Parse(Category.SelectedValue);
                if (!string.IsNullOrEmpty(QtyPerUnit.Text))
                    item.QuantityPerUnit = QtyPerUnit.Text;
                if (!string.IsNullOrEmpty(UnitPrice.Text))
                    item.UnitPrice = decimal.Parse(UnitPrice.Text);
                if (!string.IsNullOrEmpty(InStock.Text))
                    item.UnitsInStock = short.Parse(InStock.Text);
                if (!string.IsNullOrEmpty(OnOrder.Text))
                    item.UnitsOnOrder = short.Parse(OnOrder.Text);
                if (!string.IsNullOrEmpty(ReorderLevel.Text))
                    item.ReorderLevel = short.Parse(ReorderLevel.Text);
                item.Discontinued = Discontinued.Checked;

                ProductController Controller = new ProductController();
                int NewProductId = Controller.AddProduct(item);

                // Update the form and give feedback to the user
                PopulateCurrentProductsDropdown();
                this.CurrentProducts.SelectedValue = NewProductId.ToString();
                ProductID.Text = NewProductId.ToString();
                this.MessageLabel.Text = "Product added";
            }
            catch (Exception ex)
            {
                this.MessageLabel.Text = ex.Message;
                MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                MessagePanel.Visible = true;
            }
    }

    protected void UpdateProduct_Click(object sender, EventArgs e)
    {
        int theProductId;
        if (IsValid)
            if (int.TryParse(ProductID.Text, out theProductId))
            {
                try
                {
                    Product item = new Product();
                    item.ProductID = theProductId;
                    item.ProductName = ProductName.Text;
                    if (!string.IsNullOrEmpty(Supplier.SelectedValue))
                        item.SupplierID = int.Parse(Supplier.SelectedValue);
                    if (!string.IsNullOrEmpty(Category.SelectedValue))
                        item.CategoryID = int.Parse(Category.SelectedValue);
                    if (!string.IsNullOrEmpty(QtyPerUnit.Text))
                        item.QuantityPerUnit = QtyPerUnit.Text;
                    if (!string.IsNullOrEmpty(UnitPrice.Text))
                        item.UnitPrice = decimal.Parse(UnitPrice.Text);
                    if (!string.IsNullOrEmpty(InStock.Text))
                        item.UnitsInStock = short.Parse(InStock.Text);
                    if (!string.IsNullOrEmpty(OnOrder.Text))
                        item.UnitsOnOrder = short.Parse(OnOrder.Text);
                    if (!string.IsNullOrEmpty(ReorderLevel.Text))
                        item.ReorderLevel = short.Parse(ReorderLevel.Text);
                    item.Discontinued = Discontinued.Checked;

                    ProductController Controller = new ProductController();
                    int rowsAffected = Controller.UpdateProduct(item);


                    if (rowsAffected > 0)
                    {
                        // Update the form and give feedback to the user
                        PopulateCurrentProductsDropdown();
                        this.CurrentProducts.SelectedValue = item.ProductID.ToString();
                        this.MessageLabel.Text = "Product was updated";
                    }
                    else
                    {
                        this.MessageLabel.Text = "Update failed. Zero rows affected.";
                    }
                }
                catch (Exception ex)
                {
                    this.MessageLabel.Text = ex.Message;
                    MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                    MessagePanel.Visible = true;
                }
            }
            else
            {
                MessageLabel.Text = "Lookup an existing product before performing an update.";
            }
    }

    protected void DeleteProduct_Click(object sender, EventArgs e)
    {
        int theProductId;
        if (int.TryParse(ProductID.Text, out theProductId))
        {
            try
            {
                ProductController Controller = new ProductController();
                int rowsAffected = Controller.DeleteProduct(theProductId);

                if (rowsAffected > 0)
                {
                    // Update the form and give feedback to the user
                    PopulateCurrentProductsDropdown();
                    this.MessageLabel.Text = "Product was removed";
                }
                else
                {
                    this.MessageLabel.Text = "Delete failed. Zero rows affected.";
                }
            }
            catch (Exception ex)
            {
                this.MessageLabel.Text = ex.Message;
                MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                MessagePanel.Visible = true;
            }
        }
        else
        {
            MessageLabel.Text = "Lookup an existing product before attempting to delete.";
        }
    }

    protected void ClearForm_Click(object sender, EventArgs e)
    {

    }
}