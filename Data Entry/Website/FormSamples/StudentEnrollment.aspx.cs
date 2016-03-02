
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

partial class FormSamples_StudentEnrollment
    : System.Web.UI.Page
{

    protected void Page_Load(Object sender, EventArgs e)
	{
        if (!IsPostBack)
		{
            int year = DateTime.Today.Year + 1;
            int endYear = year + 4;
            while (year < endYear)
			{
                this.SchoolYear.Items.Add(year.ToString());
                year = year + 1;
		     }
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            MessageLabel.Text = "Thank you for registering. A confirmation letter will be sent to you in the next few days.";
        }
    }
}
