using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sandbox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Output.Text = "You can try out the forms on the left side of this page, and I'll show you the results (output) on this side of the page.";
        }
    }
    protected void Greet_Click(object sender, EventArgs e)
    {
        string name = FirstName.Text + " " + LastName.Text;
        string message = "Hello {0}!";
        if (!string.IsNullOrEmpty(Bio.Text))
            message = message + " I see you wrote a bio:<blockquote>"
                    + Bio.Text + "</blockquote>";

        Output.Text = string.Format(message, name);
    }
    protected void WordCount_Click(object sender, EventArgs e)
    {
        string text = Output.Text;
        string[] words = text.Split(' ');
        MessageLabel.Text = "There are " + words.Length + " words.";
    }
}