
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

partial class FormSamples_CreateBankAccount
    : System.Web.UI.Page
{
    protected void Page_Load(Object sender, EventArgs e)
    {
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            MessageLabel.Text = "Your new bank account will be processed soon.";
        }
    }
}
