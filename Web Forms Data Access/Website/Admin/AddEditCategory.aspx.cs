using NorthwindEntities;
using NorthwindSystem.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddEditCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MessagePanel.Visible = false;
        MessageLabel.Text = "";  //Clears old previous message
        //load the drop down list
        // for first time only initialization of page controls
        if (!Page.IsPostBack)
        {
            try
            {
                PopulateCategoryDropdown();
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }
    }
    private void PopulateCategoryDropdown()
    {
        // Populate Category drop-down
        CategoryController controller = new CategoryController();
        List<Category> categories = controller.ListAllCategories();
        CurrentCategories.DataSource = categories;
        CurrentCategories.DataTextField = "CategoryName";
        CurrentCategories.DataValueField = "CategoryID";
        CurrentCategories.DataBind();
        CurrentCategories.Items.Insert(0, "[select a category]");
    }


    protected void LookupCategory_Click(object sender, EventArgs e)
    {
        // if the user is required to make a selection or 
        // enter a value for the look, ensure that it has
        // been done
        if (CurrentCategories.SelectedIndex != 0)
        {
            // you should properly handle errors in a friendly manner
            try
            {
                //connect to the BLL
                CategoryController systemmgr = new CategoryController();
                //set up the data catching variable
                Category aCategory; //currently null
                // issue query request (lookup)
                aCategory = systemmgr.LookupCategory(int.Parse(CurrentCategories.SelectedValue));

                // testing for not found
                if (aCategory == null)
                {
                    MessageLabel.Text = "No data from for selected category";
                    // empty display controls
                    CategoryID.Text = "";
                    CategoryName.Text = "";
                    Description.Text = "";
                }
                else
                {
                    // load the appropriate controls with corresponding data
                    CategoryID.Text = aCategory.CategoryID.ToString();
                    CategoryName.Text = aCategory.CategoryName;
                    Description.Text = aCategory.Description;

                    if (aCategory.Picture != null)
                    {
                        byte[] picture = new byte[aCategory.Picture.Length - 78];
                        Array.Copy(aCategory.Picture, 78, picture, 0, picture.Length);
                        string base64String = Convert.ToBase64String(picture);
                        Picture.ImageUrl = "data:image/png;base64," + base64String;
                    }
                    else
                        Picture.ImageUrl = "~/Images/NoImage_172x120.gif";
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
                MessagePanel.CssClass = "alert alert-danger alert-dismissible";
                MessagePanel.Visible = true;
            }
        }
        else
        {
            MessageLabel.Text = "Select a category for searching.";
            MessagePanel.CssClass = "alert alert-info alert-dismissible";
            MessagePanel.Visible = true;
        }

    }

    protected void AddCategory_Click(object sender, EventArgs e)
    {
        try
        {
            Category item = new Category();
            item.CategoryName = CategoryName.Text;
            if (!string.IsNullOrEmpty(Description.Text))
                item.Description = Description.Text;
            item.Picture = GetUploadedPicture();

            CategoryController controller = new CategoryController();
            int addedCategoryID = controller.AddCategory(item);
            // Update the form and give feedback to the user
            PopulateCategoryDropdown();
            this.CurrentCategories.SelectedValue = addedCategoryID.ToString();
            CategoryID.Text = addedCategoryID.ToString();
            if (item.Picture != null)
                Picture.ImageUrl = "~/Handlers/ImageHandler.ashx?CategoryID="
                                 + addedCategoryID.ToString();
            else
                Picture.ImageUrl = "~/Images/NoImage_172x120.gif";
            this.MessageLabel.Text = "New category added";
        }
        catch (Exception ex)
        {
            this.MessageLabel.Text = ex.Message;
        }
    }
    private byte[] GetUploadedPicture()
    {
        byte[] thePicture = null;
        if (this.CategoryImageUpload.HasFile && this.CategoryImageUpload.PostedFile != null)
        {
            string extention = Path.GetExtension(CategoryImageUpload.PostedFile.FileName).ToLower();
            string MIMEType = "image/" + extention.Replace(".", "");
            if (WebClient.UI.Handlers.AbstractStreamableImage.ImageFormats.ContainsValue(MIMEType))
            {
                long size = this.CategoryImageUpload.PostedFile.InputStream.Length;
                if (size < int.MaxValue - 78) // minus 78 is to allow for the OLE header
                {
                    byte[] ImageBytes = new byte[size];
                    this.CategoryImageUpload.PostedFile.InputStream.Read(ImageBytes, 0, (int)size);
                    thePicture = ImageBytes;
                }
                else
                    throw new Exception("Image is too big. Images must be smaller than " +
                        int.MaxValue.ToString() + " btyes in size.");
            }
            else
            {
                throw new Exception("Invalid file type uploaded - only picture files are allowed.");
            }
        }
        return thePicture;
    }


    protected void UpdateCategory_Click(object sender, EventArgs e)
    {
        int theCategoryId;
        if (IsValid)
            if (int.TryParse(CategoryID.Text, out theCategoryId))
            {
                try
                {
                    byte[] uploadedPicture = GetUploadedPicture();
                    if (uploadedPicture != null && DeletePicture.Checked)
                    {
                        MessageLabel.Text = "Unclear input.<br />"
                            + "You selected 'Check to delete picture' and uploaded an image.";
                    }
                    else
                    {
                        // 1) Get the picture to be used in the update
                        CategoryController controller = new CategoryController();
                        if (DeletePicture.Checked)
                        {
                            uploadedPicture = null;
                        }
                        else if (uploadedPicture == null)
                        {
                            // default to the existing picture
                            uploadedPicture = controller.LookupCategory(theCategoryId).Picture;
                        }

                        // 2) Create the Category object
                        Category item = new Category();
                        item.CategoryID = theCategoryId;
                        item.CategoryName = CategoryName.Text;
                        if (!string.IsNullOrEmpty(Description.Text))
                            item.Description = Description.Text;
                        item.Picture = uploadedPicture;

                        // 3) Update the database
                        int rowsAffected = controller.UpdateCategory(item);

                        if (rowsAffected > 0)
                        {
                            PopulateCategoryDropdown();
                            this.CurrentCategories.SelectedValue = item.CategoryID.ToString();
                            if (item.Picture != null)
                                Picture.ImageUrl = "~/Handlers/ImageHandler.ashx?CategoryID="
                                                 + item.CategoryID.ToString();
                            else
                                Picture.ImageUrl = "~/Images/NoImage_172x120.gif";
                            MessageLabel.Text = "Category was updated.";
                        }
                        else
                        {
                            this.MessageLabel.Text = "Update failed. Zero rows affected.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
            else
            {
                MessageLabel.Text = "Lookup and existing category before attempting an update.";
            }
    }

    protected void DeleteCategory_Click(object sender, EventArgs e)
    {
        int theCategoryId;
        if (int.TryParse(CategoryID.Text, out theCategoryId))
        {
            try
            {
                CategoryController controller = new CategoryController();
                int rowsAffected = controller.DeleteCategory(theCategoryId);

                if (rowsAffected > 0)
                {
                    MessageLabel.Text = "Category " + CategoryName.Text + " deleted";
                    PopulateCategoryDropdown();
                    CategoryID.Text = string.Empty;
                    CategoryName.Text = string.Empty;
                    Description.Text = string.Empty;
                    Picture.ImageUrl = "~/Images/NoImage_172x120.gif";
                }
                else
                {
                    this.MessageLabel.Text = "Delete failed. Zero rows affected.";
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }
        else
        {
            MessageLabel.Text = "Lookup and existing category before attempting to delete.";
        }
    }

    protected void ClearForm_Click(object sender, EventArgs e)
    {

    }
}