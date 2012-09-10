using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using CrystalDecisions.CrystalReports.Engine;

public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        GenerateReport();
    }

    protected void GenerateReport()
    {
        
    }
    protected void gv_extracurricular_log_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
