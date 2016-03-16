using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAid.Entities;

public partial class TravelAidForm : System.Web.UI.Page
{
    private static List<Translation> TravelDictionary = new List<Translation>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            PopulateGridView();
        }
            
    }
    protected void AddPhrase_Click(object sender, EventArgs e)
    {
        if(IsValid)
        {
            Translation phrase = new Translation();
            phrase.English = English.Text;
            phrase.Klingon = Klingon.Text;
            TravelDictionary.Add(phrase);
            PopulateGridView();
        }
    }
    private void PopulateGridView()
    {
        TranslationGridView.DataSource = TravelDictionary;
        TranslationGridView.DataBind();
    }
}