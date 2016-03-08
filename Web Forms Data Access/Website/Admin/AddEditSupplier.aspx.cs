using NorthwindEntities;
using NorthwindSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddEditSupplier : System.Web.UI.Page
{
    #region Event Handlers"
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!this.IsPostBack)
        {
            try
            {
                BindSupplierDropDown();
                BindCountryDropDown();
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }
    }

    protected void LookupSupplier_Click(object sender, System.EventArgs e)
    {
        try
        {
            int supplierId;
            if (int.TryParse(this.SupplierDropDownList.SelectedValue, out supplierId) && supplierId >= 0)
            {
                Supplier item;
                SupplierController Controller = new SupplierController();
                item = Controller.LookupSupplier(supplierId);
                // TODO: With Item
                this.CurrentSupplier.Text = item.SupplierID.ToString();
                this.CompanyName.Text = item.CompanyName;
                this.ContactName.Text = item.ContactName;
                this.ContactTitle.Text = item.ContactTitle;
                this.Address.Text = item.Address;
                this.City.Text = item.City;
                this.Region.Text = item.Region;
                this.PostalCode.Text = item.PostalCode;
                this.CountryDropDown.SelectedValue = item.Country;
                this.Phone.Text = item.Phone;
                this.Fax.Text = item.Fax;
                this.HomePage.Text = item.HomePage;
                this.HomePage.NavigateUrl = item.Address;

                this.DisplayText.Text = item.DisplayText;
                this.WebAddress.Text = item.Address;
                this.SubAddress.Text = item.SubAddress;
                // End With
            }
            else
            {
                MessageLabel.Text = "Please Select a supplier before clicking Lookup";
            }
        }
        catch (Exception ex)
        {
            MessageLabel.Text = ex.Message;
        }
    }

    protected void AddSupplier_Click(object sender, System.EventArgs e)
    {
        try
        {
            if (this.IsValid)
            {
                // 1) Add the product as a new item
                // Build the HomePage string
                string homePage = string.Join("#", this.DisplayText.Text, this.WebAddress.Text, this.SubAddress.Text);
                if (homePage.Equals("###"))
                    homePage = null;

                // Get the Country name
                string Country = null;
                if (this.CountryDropDown.SelectedIndex > 0)
                {
                    Country = this.CountryDropDown.SelectedValue;
                }

                Supplier Item = new Supplier(-1, this.CompanyName.Text,
                           this.ContactName.Text,
                           this.ContactTitle.Text,
                           this.Address.Text,
                           this.City.Text,
                           this.Region.Text,
                           this.PostalCode.Text,
                           Country,
                           this.Phone.Text,
                           this.Fax.Text,
                           HomePage.ToString());
                SupplierController Controller = new SupplierController();
                int NewSupplierId = Controller.AddSupplier(Item);

                // 2) Update the form and give feedback to the user
                BindSupplierDropDown();
                this.SupplierDropDownList.SelectedValue = NewSupplierId.ToString();
                CurrentSupplier.Text = NewSupplierId.ToString();
                MessageLabel.Text = "Supplier added";
            }
        }
        catch (Exception ex)
        {
            MessageLabel.Text = ex.Message;
        }
    }
    #endregion

    #region Private Methods"
    private void BindSupplierDropDown()
    {
        SupplierController controller = new SupplierController();
        this.SupplierDropDownList.DataSource = controller.ListAllSuppliers();
        this.SupplierDropDownList.DataTextField = "CompanyName";
        this.SupplierDropDownList.DataValueField = "SupplierID";
        this.SupplierDropDownList.DataBind();
        this.SupplierDropDownList.Items.Insert(0, new ListItem("[Select a supplier]", "-1"));
    }

    private void BindCountryDropDown()
    {
        CountryController controller = new CountryController();
        this.CountryDropDown.DataSource = controller.ListAllCountries();
        this.CountryDropDown.DataTextField = "Country";
        this.CountryDropDown.DataValueField = "Country";
        this.CountryDropDown.DataBind();
        this.CountryDropDown.Items.Insert(0, new ListItem("[Select a Country]", "-1"));
        this.CountryDropDown.Items.Insert(1, new ListItem("[no Country]", ""));
    }

    private void ValidateCurrentSupplierID()
    {
        int temp;
        if (!int.TryParse(CurrentSupplier.Text, out temp))
            MessageLabel.Text = "You can only update/delete an existing Supplier";
        else
            if (!CurrentSupplier.Text.Equals(SupplierDropDownList.SelectedValue))
                MessageLabel.Text = "The supplier selected in the drop-down is not the same as the supplier details in the form; it is not clear which one you want to modify.<br />Please Select the supplier you want to modify before clicking Update or Delete.";
    }
    #endregion
    protected void UpdateSupplier_Click(object sender, EventArgs e)
    {

    }
    protected void DeleteSupplier_Click(object sender, EventArgs e)
    {

    }
    protected void ClearForm_Click(object sender, EventArgs e)
    {

    }
}