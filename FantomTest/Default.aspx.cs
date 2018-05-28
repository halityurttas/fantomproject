using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //fantom configuration for read settings
        Fantom.Configuration.ConfigurationManager _fantomConf = new Fantom.Configuration.ConfigurationManager();
        //setup site culture
        //Warning! Page load methods call after object initialize. Therefore firs run not effective, please page refresh.
        //This is testing purposes, you should use an appropriate method.
        Session[_fantomConf.Configuration.CultureSessionKey] = "tr-TR";

        //fantom datamanager for get language key value
        Fantom.Data.DataManager _fantomData = new Fantom.Data.DataManager();
        //set page title from fantom key
        Page.Title = _fantomData.GetKeyValue("MAIN", "HELLO");
    }
}