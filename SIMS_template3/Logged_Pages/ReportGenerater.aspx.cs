﻿using System;
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

public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        RepPnl.Controls.Add(LoadControl("Academic_Reports/BestPerformance.ascx"));
    }
}
